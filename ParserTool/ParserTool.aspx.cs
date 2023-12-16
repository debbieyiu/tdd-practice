using System;
using System.Collections.Generic;
using System.Linq;
using ParserTool.Libraries.Models;
using ParserTool.Libraries.Modules.WithdrawalBankList;

namespace ParserTool
{
    public partial class ParserTool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* SOURCE
              {
                   "PaymentId": "PaySec",
                   "Enable": false,
                   "paymentInfoByCurrency": [
                      {
                        "CurrencyId": 13,
                        "Enable": false,
                        "ModeInfoList": [
                            {
                               "Id": 95109,
                               "SupportCryptoCurrencies": [ "Usdt|Usdc" ]
                            }
                        ]
                      }
                    ]
               }
             */

            var withdrawalConfigs = WithdrawalBankListConfigHelper.Instance.Config.PaymentEnable;
            var backgroundItems = withdrawalConfigs
                .Where(config => config.PaymentId == "SDPay")
                .Select(ConvertToBackgroundItem)
                .ToList();

            backgroundItems.ForEach(item => item.Process());

            /* EXPECTED RESULT
             * PaymentId, PaymentKind
             *   OnlineType, Currencies
             *     Currency, ModeInfos
             *       ModeInfo
             */
            txtResult.Text = "test";
        }

        private static List<ConfigsByModeInfo> ConvertConfigsByModeInfo(
            PaymentEnable config,
            PaymentInfoByCurrency currency,
            ModeInfo modeInfo)
        {
            var configsByModeInfo = InitConfigsByModeInfo(config, currency, modeInfo, PaymentOnlineType.Online);

            var result = new List<ConfigsByModeInfo>();
            var supportCryptoCurrencies = modeInfo.SupportCryptoCurrencies;
            if (supportCryptoCurrencies.Any())
            {
                foreach (var supportCryptoCurrency in supportCryptoCurrencies)
                {
                    foreach (var onlineType in supportCryptoCurrency.ExtListRelatedDepositOnlineTypes())
                    {
                        var info = InitConfigsByModeInfo(config, currency, modeInfo, onlineType);
                        result.Add(info);
                    }
                }

                return result;
            }

            return new List<ConfigsByModeInfo> { configsByModeInfo };
        }

        private static ParseType GetParseType(string paymentId)
        {
            var noneCases = new List<string> { "_1ClickPay", "AeePay", "CapitalPay", "DBINPay", "EchelonPay", "EeziePay", "JustPay", "OOPayNew", "OOPay", "PandaPay", "RarepidPay", "S88Pay", "XPay" };
            if (noneCases.Contains(paymentId))
            {
                return ParseType.None;
            }

            var wdDictionaryCases = new List<string> { "NewXfuooUsdt", "DirePay" };
            if (wdDictionaryCases.Contains(paymentId))
            {
                return ParseType.WdDictionary;
            }

            return ParseType.WdJson;
        }

        private static ConfigsByModeInfo InitConfigsByModeInfo(
            PaymentEnable config,
            PaymentInfoByCurrency currency,
            ModeInfo modeInfo,
            PaymentOnlineType onlineType)
        {
            return new ConfigsByModeInfo
            {
                PaymentId = config.PaymentId,
                CurrencyId = currency.CurrencyId,
                ModeId = modeInfo.Id,
                TargetName = modeInfo.GetTargetName(config.PaymentId, (Currency)currency.CurrencyId, onlineType),
                OnlineType = onlineType,
                ParseType = GetParseType(config.PaymentId)
            };
        }

        private ConfigsByCurrency ConvertConfigsByCurrency(
            PaymentEnable paymentEnable,
            int currency,
            List<ConfigsByModeInfo> modeInfos)
        {
            return new ConfigsByCurrency
            {
                PaymentId = paymentEnable.PaymentId,
                CurrencyId = currency,
                ModeInfoList = modeInfos
            };
        }

        private BackgroundItem ConvertToBackgroundItem(PaymentEnable config)
        {
            var configsByModeInfo = config.PaymentInfoByCurrency
                .SelectMany(
                    currency => currency.ModeInfoList,
                    (currency, modeInfo) =>
                        ConvertConfigsByModeInfo(config, currency, modeInfo))
                .SelectMany(list => list)
                .ToList();

            var configsByCurrency = configsByModeInfo
                .GroupBy(info => info.CurrencyId,
                    (currency, modeInfo) =>
                        ConvertConfigsByCurrency(config, currency, modeInfo.ToList()))
                .ToList();

            return configsByCurrency
                .GroupBy(info => info.PaymentId)
                .Select(grouping => new BackgroundItem(PaymentKind.Withdrawal, grouping.Key, grouping.ToList()))
                .First();
        }
    }
}
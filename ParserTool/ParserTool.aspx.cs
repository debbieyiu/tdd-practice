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
                .Where(config => config.PaymentId == "DirePay")
                .Select(ConvertToBackgroundItem)
                .ToList();

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
                TargetName = modeInfo.Id.ToString(),
                OnlineType = onlineType,
                ParseType = ParseType.WdJson
            };
        }

        private BackgroundItem ConvertToBackgroundItem(PaymentEnable config)
        {
            var configsByModeInfo = config.PaymentInfoByCurrency
                .SelectMany(
                    currency => currency.ModeInfoList,
                    (currency, modeInfo) => ConvertConfigsByModeInfo(config, currency, modeInfo))
                .SelectMany(list => list)
                .ToList();

            var ddd = configsByModeInfo
                .GroupBy(info =>
                    new Tuple<string, PaymentOnlineType, int>(info.PaymentId, info.OnlineType, info.CurrencyId))
                .Select(grouping => new Tuple<string, PaymentOnlineType, int, List<ModeContent>>
                (
                    grouping.Key.Item1,
                    grouping.Key.Item2,
                    grouping.Key.Item3,
                    ConvertToModeContents(grouping.ToList())
                ))
                .GroupBy(info => new Tuple<string, PaymentOnlineType>(info.Item1, info.Item2))
                .Select(grouping => new Tuple<string, PaymentOnlineType, List<CurrencyContent>>
                (
                    grouping.Key.Item1,
                    grouping.Key.Item2,
                    ConvertToCurrencyContents(grouping.ToList()))
                ))
                .ToList();

            // return configsByModeInfo
            //     .GroupBy(info => new Tuple<string, PaymentOnlineType>(info.PaymentId, info.OnlineType))
            //     .FirstOrDefault(grouping => new BackgroundItem
            //     {
            //         PaymentId = grouping.Key.Item1,
            //         OnlineType = grouping.Key.Item2
            //     });

            // group by PaymentId
            return new BackgroundItem();
        }

        private List<CurrencyContent> ConvertToCurrencyContents(List<Tuple<string, PaymentOnlineType, int, List<ModeContent>>> toList)
        {
            return new List<CurrencyContent>();
        }

        private List<ModeContent> ConvertToModeContents(List<ConfigsByModeInfo> toList)
        {
            return toList
                .Select(info => new ModeContent
                {
                    ModeId = info.ModeId,
                    TargetName = info.TargetName,
                    ParseType = info.ParseType
                }).ToList();
        }
    }

    internal class CurrencyContent
    {
    }

    internal class ModeContent
    {
        public int ModeId { get; set; }
        public ParseType ParseType { get; set; }
        public string TargetName { get; set; }
    }
}
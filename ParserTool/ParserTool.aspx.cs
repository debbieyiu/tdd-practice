using System;
using System.Collections.Generic;
using System.Linq;
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
            var configsByModeInfo = new ConfigsByModeInfo
            {
                PaymentId = config.PaymentId,
                CurrencyId = currency.CurrencyId,
                ModeId = modeInfo.Id,
                TargetName = modeInfo.Id.ToString(),
                OnlineType = PaymentOnlineType.Online,
                ParseType = ParseType.WdJson
            };

            var result = new List<ConfigsByModeInfo>();
            var supportCryptoCurrencies = modeInfo.SupportCryptoCurrencies;
            if (supportCryptoCurrencies.Any())
            {
                foreach (var supportCryptoCurrency in supportCryptoCurrencies)
                {
                    result.Add(configsByModeInfo);
                    result.Add(configsByModeInfo);
                }

                return result;
            }

            return new List<ConfigsByModeInfo> { configsByModeInfo };
        }

        private BackgroundItem ConvertToBackgroundItem(PaymentEnable config)
        {
            var configsByModeInfo = config.PaymentInfoByCurrency
                .SelectMany(
                    currency => currency.ModeInfoList,
                    (currency, modeInfo) => ConvertConfigsByModeInfo(config, currency, modeInfo))
                .SelectMany(list => list)
                .ToList();

            // group by PaymentId
            return new BackgroundItem();
        }
    }
}
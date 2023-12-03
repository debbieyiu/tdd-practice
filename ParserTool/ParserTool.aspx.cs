using System;
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
                .Where(config => config.PaymentId == "AllpassPay")
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

        private BackgroundItem ConvertToBackgroundItem(PaymentEnable config)
        {
            var flattenConfigsByPayment = config.PaymentInfoByCurrency
                .SelectMany(
                    currency => currency.ModeInfoList,
                    (currency, modeInfo) => new FlattenConfigsByPayment
                    {
                        PaymentId = config.PaymentId,
                        CurrencyId = currency.CurrencyId,
                        ModeId = modeInfo.Id,
                        TargetName = "Online"
                    })
                .ToList();
            // group by PaymentId then into BackgroundItem
            return new BackgroundItem();
        }
    }
}
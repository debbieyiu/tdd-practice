using System.Collections.Generic;
using ParserTool.Libraries.Models;

namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public class ModeInfo
    {
        public ModeInfo()
        {
            SupportCryptoCurrencies = new CryptoCurrency[] { };
        }

        public int Id { get; set; }
        public decimal? Max { get; set; }
        public decimal? Min { get; set; }
        public CryptoCurrency[] SupportCryptoCurrencies { get; set; }

        public string GetTargetName(string paymentId, Currency currency, PaymentOnlineType onlineType)
        {
            var currencySpecialCases = new List<string> { "Help2Pay", "DirePay" };
            if (currencySpecialCases.Contains(paymentId))
            {
                return currency.ToString().ToLower();
            }

            var modeIdCurrencyCases = new List<string> { "GameWallet", "SDPay", "_1ClickPay", "EeziePay", "JustPay", "XPay" };
            if (modeIdCurrencyCases.Contains(paymentId))
            {
                return $"{Id}{currency.ToString().ToLower()}";
            }

            return Id.ToString();
        }
    }
}
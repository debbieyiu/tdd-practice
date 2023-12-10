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
    }
}
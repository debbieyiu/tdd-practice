using System.Collections.Generic;

namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public class SupportBankList
    {
        public int CurrencyId { get; set; }
        public IList<BankInfo> BankInfo { get; set; }
    }
}
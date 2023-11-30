using System.Collections.Generic;

namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public class BankInfo
    {
        public string BankId { get; set; }
        public string Name { get; set; }
        public IList<SupportPayment> SupportPayment { get; set; }
    }
}
using System.Collections.Generic;

namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public class WithdrawalBankListConfig
    {
        public List<PaymentEnable> PaymentEnable { get; set; }
        public List<SupportBankList> SupportBankList { get; set; }

        public WithdrawalBankListConfig()
        {
            PaymentEnable = new List<PaymentEnable>();
            SupportBankList = new List<SupportBankList>();
        }
    }
}
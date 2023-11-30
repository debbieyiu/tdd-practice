using System.Collections.Generic;

namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public class PaymentEnable
    {
        public string PaymentId { get; set; }
        public bool Enable { get; set; }
        public IList<PaymentInfoByCurrency> PaymentInfoByCurrency { get; set; }
    }
}
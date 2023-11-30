using System.Collections.Generic;

namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public class PaymentInfoByCurrency
    {
        public int CurrencyId { get; set; }
        public bool Enable { get; set; }
        public int? Divisor { get; set; }
        public List<ModeInfo> ModeInfoList { get; set; }
    }
}
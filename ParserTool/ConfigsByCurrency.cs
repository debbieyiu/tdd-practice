using System.Collections.Generic;

namespace ParserTool
{
    internal class ConfigsByCurrency
    {
        public int CurrencyId { get; set; }
        public List<ConfigsByModeInfo> ModeInfoList { get; set; }
        public string PaymentId { get; set; }
    }
}
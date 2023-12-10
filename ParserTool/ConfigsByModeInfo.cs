using ParserTool.Libraries.Models;

namespace ParserTool
{
    internal class ConfigsByModeInfo
    {
        public int CurrencyId { get; set; }
        public int ModeId { get; set; }
        public PaymentOnlineType OnlineType { get; set; }
        public ParseType ParseType { get; set; }
        public string PaymentId { get; set; }
        public string TargetName { get; set; }
    }
}
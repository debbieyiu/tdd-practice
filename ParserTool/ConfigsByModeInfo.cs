namespace ParserTool
{
    internal class ConfigsByModeInfo
    {
        public string PaymentId { get; set; }
        public int CurrencyId { get; set; }
        public int ModeId { get; set; }
        public string TargetName { get; set; }
        public PaymentOnlineType OnlineType { get; set; }
        public ParseType ParseType { get; set; }
    }
}
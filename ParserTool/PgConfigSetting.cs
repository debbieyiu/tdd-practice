using ParserTool.Libraries.Models;

namespace ParserTool
{
    internal class PgConfigSetting
    {
        public PgConfigSetting(string targetName, PaymentOnlineType onlineType, ChargeFeeSetting chargeFeeSetting)
        {
            TargetName = targetName;
            OnlineType = onlineType;
            ChargeFeeSetting = chargeFeeSetting;
        }

        public ChargeFeeSetting ChargeFeeSetting { get; set; }
        public bool IsSet { get; set; }
        public PaymentOnlineType OnlineType { get; set; }
        public string TargetName { get; set; }
    }
}
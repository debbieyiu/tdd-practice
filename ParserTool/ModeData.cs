using System.Collections.Generic;

namespace ParserTool
{
    internal class ModeData
    {
        public List<PgConfigSetting> ChargeFeeSettings { get; set; }
        public int ModeId { get; set; }
        public ParseType ParseType { get; set; }
        public string TargetName { get; set; }
    }
}
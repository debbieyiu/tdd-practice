using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using ParserTool.Libraries.Models;

namespace ParserTool
{
    internal class BackgroundItem
    {
        public BackgroundItem(
            PaymentKind paymentKind,
            string paymentId,
            List<ConfigsByCurrency> configsByCurrency)
        {
            PaymentKind = paymentKind;
            PaymentId = paymentId;
            CurrencyDataList = configsByCurrency
                .Select(currency => new CurrencyData
                {
                    Currency = (Currency)currency.CurrencyId,
                    OnlineTypeDataList = currency.ModeInfoList
                        .GroupBy(info => info.OnlineType)
                        .Select(grouping => new OnlineTypeData
                        {
                            OnlineType = grouping.Key,
                            ModeDataList = grouping.ToList()
                                .Select(info => new ModeData
                                {
                                    ModeId = info.ModeId,
                                    TargetName = info.TargetName,
                                    ParseType = info.ParseType
                                })
                                .ToList()
                        })
                        .ToList()
                })
                .ToList();
        }

        public List<CurrencyData> CurrencyDataList { get; set; }

        public string PaymentId { get; set; }

        public PaymentKind PaymentKind { get; set; }

        public List<PgConfigSetting> PgConfigSettings { get; set; }

        public void Process()
        {
            var xmlDocument = new XmlDocument();
            var fileName =
                HttpContext.Current.Server.MapPath(
                    $"~/App_Data/Setting/ThirdParty/{PaymentId}WithdrawalSetting.config");

            xmlDocument.Load(fileName);
            var root = xmlDocument.DocumentElement;
            var targetNodes = root.SelectSingleNode("targets").ChildNodes.Cast<XmlNode>()
                .Where(GetNonCommonTargetElements)
                .ToList();

            PgConfigSettings = targetNodes
                .Select(ConvertToPgConfigSettings)
                .SelectMany(list => list)
                .ToList();
        }

        private List<PgConfigSetting> ConvertToPgConfigSettings(XmlNode node)
        {
            var targetName = string.Empty;
            if (GeneralHelper.TryGetAttribute(node, "name", out var result))
            {
                targetName = result;
            }

            var settings = node.SelectSingleNode("ChargeFeeSetting").InnerText;

            return new List<PgConfigSetting>();
        }

        private bool GetNonCommonTargetElements(XmlNode arg)
        {
            if (arg.NodeType == XmlNodeType.Element)
            {
                return arg.Attributes.Cast<XmlAttribute>()
                    .Any(arg1 => arg1.Name == "name" && arg1.Value != "common");
            }

            return false;
        }
    }

    internal class ChargeFeeSetting
    {
    }

    internal class PgConfigSetting
    {
    }
}
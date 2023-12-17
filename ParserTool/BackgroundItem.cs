using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
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

        public List<Tuple<BackgroundItem, CurrencyData, OnlineTypeData, ModeData>> FlattenItems => CurrencyDataList
            .SelectMany(
                bgCurrency => bgCurrency.OnlineTypeDataList,
                (bgCurrency, bgOnlineType) =>
                    new { bgCurrency, bgOnlineType })
            .SelectMany(
                bgCurrencyOnlineType => bgCurrencyOnlineType.bgOnlineType.ModeDataList,
                (bgCurrencyOnlineType, bgMode) =>
                    new Tuple<BackgroundItem, CurrencyData, OnlineTypeData, ModeData>(
                    this, bgCurrencyOnlineType.bgCurrency, bgCurrencyOnlineType.bgOnlineType, bgMode))
            .ToList();

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

            var list = new List<PgConfigSetting>();
            var parseType = FlattenItems.First().Item4.ParseType;
            switch (parseType)
            {
                case ParseType.None:
                    break;

                case ParseType.WdJson:
                    var chargeFeeSetting = JsonConvert.DeserializeObject<ChargeFeeSetting>(settings);
                    var pgConfigSetting = new PgConfigSetting(targetName, PaymentOnlineType.Online, chargeFeeSetting);
                    list.Add(pgConfigSetting);
                    break;

                case ParseType.WdDictionary:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return list;
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
}
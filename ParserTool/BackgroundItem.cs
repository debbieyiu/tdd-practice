using System.Collections.Generic;
using System.Linq;

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
    }
}
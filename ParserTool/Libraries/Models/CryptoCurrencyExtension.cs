using System.Collections.Generic;
using System.Linq;

namespace ParserTool.Libraries.Models
{
    public static class CryptoCurrencyExtension
    {
        public static List<PaymentOnlineType> ExtListRelatedDepositOnlineTypes(this CryptoCurrency cryptoCurrency)
        {
            return cryptoCurrency
                .TryGetAttribute<RelatedDepositOnlineTypesAttribute>(out var result)
                ? result.OnlineTypes.ToList()
                : null;
        }
    }
}
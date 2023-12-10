using System.ComponentModel;

namespace ParserTool.Libraries.Models
{
    public enum CryptoCurrency
    {
        [RelatedDepositOnlineTypes(PaymentOnlineType.UsdtErc20, PaymentOnlineType.UsdtTrc20)]
        [Description("USDT")]
        Usdt,

        [Description("ETH")]
        Eth,

        [RelatedDepositOnlineTypes(PaymentOnlineType.UsdcErc20, PaymentOnlineType.UsdcTrc20)]
        [Description("USDC")]
        Usdc,

        [RelatedDepositOnlineTypes(PaymentOnlineType.CryptoBtc)]
        [Description("BTC")]
        Btc,
    }
}
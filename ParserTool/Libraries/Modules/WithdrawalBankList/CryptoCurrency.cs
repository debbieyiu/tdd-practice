using System.ComponentModel;

namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public enum CryptoCurrency
    {
        [Description("USDT")] Usdt,
        [Description("ETH")] Eth,
        [Description("USDC")] Usdc,
        [Description("BTC")] Btc,
    }
}
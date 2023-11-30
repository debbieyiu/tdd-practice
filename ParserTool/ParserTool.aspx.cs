using System;
using ParserTool.Libraries.Modules.WithdrawalBankList;

namespace ParserTool
{
    public partial class ParserTool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var withdrawalConfig = WithdrawalBankListConfigHelper.Instance.Config.PaymentEnable;

            txtResult.Text = "test";
        }
    }
}
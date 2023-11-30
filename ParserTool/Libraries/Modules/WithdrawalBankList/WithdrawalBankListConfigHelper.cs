namespace ParserTool.Libraries.Modules.WithdrawalBankList
{
    public class WithdrawalBankListConfigHelper : ModuleBase<WithdrawalBankListConfig, WithdrawalBankListConfigHelper>
    {
        protected override string GetConfigFilePath()
        {
            return "~/App_Data/WithdrawalBankList.json";
        }
    }
}
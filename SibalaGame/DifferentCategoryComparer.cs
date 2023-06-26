namespace SibalaGame
{
    public class DifferentCategoryComparer : IComparer
    {
        public string WinnerCategoryName { get; private set; }
        public string WinnerOutput { get; private set; }

        public int Compare(Dices dices1, Dices dices2)
        {
            var category1 = dices1.GetCategory();
            var category2 = dices2.GetCategory();

            var compareResult = category1.Type - category2.Type;

            if (compareResult != 0)
            {
                var winnerCategory = compareResult > 0 ? category1 : category2;
                WinnerCategoryName = winnerCategory.Name;
                WinnerOutput = winnerCategory.Output;
            }

            return compareResult;
        }
    }
}
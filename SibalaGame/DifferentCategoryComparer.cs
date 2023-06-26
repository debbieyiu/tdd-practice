namespace SibalaGame
{
    public class DifferentCategoryComparer : IComparer
    {
        public Category WinnerCategory { get; set; }

        public int Compare(Dices dices1, Dices dices2)
        {
            var category1 = dices1.GetCategory();
            var category2 = dices2.GetCategory();

            var compareResult = category1.Type - category2.Type;

            if (compareResult != 0)
            {
                WinnerCategory = compareResult > 0 ? category1 : category2;
            }

            return compareResult;
        }
    }
}
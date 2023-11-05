namespace SibalaGame
{
    public class DifferentCategoryComparer : ICompare
    {
        public int Compare(Dices dices1, Dices dices2)
        {
            WinnerOutputDisplay = "5";
            return dices1.CategoryType - dices2.CategoryType;
        }

        public string WinnerCategoryDisplay => "all of a kind";
        public string WinnerOutputDisplay { get; set; }
    }
}
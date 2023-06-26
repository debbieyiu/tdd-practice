namespace SibalaGame
{
    public class DifferentCategoryComparer : IComparer
    {
        public string WinnerCategoryName { get; private set; }
        public string WinnerOutput { get; private set; }

        public int Compare(Dices dices1, Dices dices2)
        {
            WinnerCategoryName = dices1.GetCategory().Name; // "all of a kind";
            WinnerOutput = "5";
            return 1;
        }
    }
}
namespace SibalaGame
{
    public class DifferentCategoryComparer : IComparer
    {
        public string WinnerCategoryName { get; private set; }
        public string WinnerOutput { get; private set; }

        public int Compare(Dices dices1, Dices dices2)
        {
            var category = dices1.GetCategory();
            WinnerCategoryName = category.Name; // "all of a kind";
            WinnerOutput = category.Output;
            return 1;
        }
    }
}
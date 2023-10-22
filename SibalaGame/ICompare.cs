namespace SibalaGame
{
    public interface ICompare
    {
        int Compare(Dices dices1, Dices dices2);
        string WinnerCategoryDisplay { get; set; }
        string WinnerOutputDisplay { get; set; }
    }
}
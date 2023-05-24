using System.Collections.Generic;

namespace SibalaGame
{
    public interface IComparer
    {
        string WinnerCategoryName { get; }
        string WinnerOutput { get; }

        int Compare(List<Dice> dices1, List<Dice> dices2);
    }
}
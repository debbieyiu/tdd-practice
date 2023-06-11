using System.Collections.Generic;

namespace SibalaGame
{
    public interface IComparer
    {
        string WinnerCategoryName { get; }
        string WinnerOutput { get; }

        int Compare(Dices dices1, Dices dices2);
    }
}
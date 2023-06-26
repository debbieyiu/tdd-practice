using System.Collections.Generic;

namespace SibalaGame
{
    public interface IComparer
    {
        Category WinnerCategory { get; }

        int Compare(Dices dices1, Dices dices2);
    }
}
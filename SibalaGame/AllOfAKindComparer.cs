using System.Collections.Generic;
using NUnit.Framework;

namespace SibalaGame
{
    public class AllOfAKindComparer
    {
        public string WinnerCategoryName => "all of a kind";

        public string WinnerOutput { get; private set; }

        public int CompareResult(Dice player1Dice, Dice player2Dice)
        {
            var valueOrdering = new List<int> { 2, 3, 5, 6, 4, 1 };
            var compareResult = valueOrdering.IndexOf(player1Dice.Value) - valueOrdering.IndexOf(player2Dice.Value);
            if (compareResult != 0)
            {
                WinnerOutput = compareResult > 0 ? player1Dice.Output : player2Dice.Output;
            }

            return compareResult;
        }
    }
}
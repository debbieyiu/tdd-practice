using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class AllOfAKindComparer
    {
        public string WinnerCategoryDisplay { get; set; } = "all of a kind";
        public string WinnerOutputDisplay { get; set; }

        public int Compare(Dices dices1, Dices dices2)
        {
            var valueOrdering = new List<int> { 2, 3, 5, 6, 4, 1 };
            var dice1ValueIndex = valueOrdering.IndexOf(dices1.First().Value);
            var dice2ValueIndex = valueOrdering.IndexOf(dices2.First().Value);

            var dices1CompareValue = dices1.GetDicesCompareValue();

            var compareResult = dices1CompareValue - dice2ValueIndex;
            if (compareResult != 0)
            {
                WinnerOutputDisplay = compareResult > 0 ? dices1.First().Output : dices2.First().Output;
            }

            return compareResult;
        }
    }
}
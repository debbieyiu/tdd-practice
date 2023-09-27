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
            var dices1CompareValue = dices1.GetDicesCompareValue();
            var dices2CompareValue = dices2.GetDicesCompareValue();

            var compareResult = dices1CompareValue - dices2CompareValue;
            if (compareResult != 0)
            {
                WinnerOutputDisplay = compareResult > 0 ? dices1.First().Output : dices2.First().Output;
            }

            return compareResult;
        }
    }
}
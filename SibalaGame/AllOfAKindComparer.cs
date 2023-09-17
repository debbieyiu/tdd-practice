using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class AllOfAKindComparer
    {
        public string WinnerCategoryDisplay { get; set; } = "all of a kind";
        public string WinnerOutputDisplay { get; set; }

        public int Compare(List<Dice> dices1, List<Dice> dices2)
        {
            var compareResult = dices1.First().Value - dices2.First().Value;
            if (compareResult != 0)
            {
                WinnerOutputDisplay = compareResult > 0 ? dices1.First().Output : dices2.First().Output;
            }

            return compareResult;
        }
    }
}
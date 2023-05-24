using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SibalaGame
{
    public class AllOfAKindComparer
    {
        public string WinnerCategoryName => "all of a kind";

        public string WinnerOutput { get; private set; }

        public int Compare(List<Dice> dices1, List<Dice> dices2)
        {
            var valueOrdering = new List<int> { 2, 3, 5, 6, 4, 1 };
            var compareResult = valueOrdering.IndexOf(dices1.First().Value) - valueOrdering.IndexOf(dices2.First().Value);
            if (compareResult != 0)
            {
                WinnerOutput = compareResult > 0 ? dices1.First().Output : dices2.First().Output;
            }

            return compareResult;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class AllOfAKindComparer : IComparer
    {
        public string WinnerCategoryName => "all of a kind";

        public string WinnerOutput { get; private set; }

        public int Compare(Dices dices1, Dices dices2)
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
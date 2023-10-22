using System.Linq;

namespace SibalaGame
{
    public class AllOfAKindComparer : ICompare
    {
        public string WinnerCategoryDisplay => "all of a kind";

        public string WinnerOutputDisplay { get; set; }

        public int Compare(Dices dices1, Dices dices2)
        {
            var dice1ValueIndex = dices1.GetCompareValue();
            var dice2ValueIndex = dices2.GetCompareValue();

            var compareResult = dice1ValueIndex - dice2ValueIndex;
            if (compareResult != 0)
            {
                WinnerOutputDisplay = compareResult > 0 ? dices1.First().Output : dices2.First().Output;
            }

            return compareResult;
        }
    }
}
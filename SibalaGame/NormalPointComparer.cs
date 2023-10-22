using System.Linq;

namespace SibalaGame
{
    public class NormalPointComparer : ICompare
    {
        public int Compare(Dices dices1, Dices dices2)
        {
            var compareResult = dices1.GetCompareValue() - dices2.GetCompareValue();
            if (compareResult == 0)
            {
                compareResult = dices1.Max(dice => dice.Value) - dices2.Max(dice => dice.Value);
            }

            WinnerOutputDisplay = compareResult > 0 ? dices1.GetCompareValue().ToString() : dices2.GetCompareValue().ToString();
            return compareResult;
        }

        public string WinnerCategoryDisplay => "normal point";
        public string WinnerOutputDisplay { get; set; }
    }
}
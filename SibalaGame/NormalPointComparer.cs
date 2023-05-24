using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class NormalPointComparer : IComparer
    {
        public string WinnerCategoryName => "normal point";
        public string WinnerOutput { get; private set; }

        public int Compare(List<Dice> player1Dices, List<Dice> player2Dices)
        {
            var diceValuePlayer1 = CalculateNormalPoint(player1Dices);
            var diceValuePlayer2 = CalculateNormalPoint(player2Dices);

            var compareResult2 = diceValuePlayer1 - diceValuePlayer2;
            WinnerOutput = compareResult2 > 0 ? diceValuePlayer1.ToString() : diceValuePlayer2.ToString();
            return compareResult2;
        }

        private static int CalculateNormalPoint(List<Dice> dices)
        {
            var pairs = dices.GroupBy(dice => dice.Value)
                .First(grouping => grouping.Count() == 2)
                .ToList();
            return dices.Except(pairs).Sum(dice => dice.Value);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class NormalPointComparer
    {
        public int Compare(List<Dice> player1Dices, List<Dice> player2Dices, out string winnerOutput)
        {
            var dices1 = player1Dices.GroupBy(dice => dice.Value)
                .First(grouping => grouping.Count() == 2)
                .ToList();
            var diceValuePlayer1 = player1Dices.Except(dices1).Sum(dice => dice.Value);

            var dices2 = player2Dices.GroupBy(dice => dice.Value)
                .First(grouping => grouping.Count() == 2)
                .ToList();
            var diceValuePlayer2 = player2Dices.Except(dices2).Sum(dice => dice.Value);
            var compareResult2 = diceValuePlayer1 - diceValuePlayer2;
            winnerOutput = compareResult2 > 0 ? diceValuePlayer1.ToString() : diceValuePlayer2.ToString();
            return compareResult2;
        }
    }
}
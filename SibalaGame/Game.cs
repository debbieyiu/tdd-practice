using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace SibalaGame
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);

            var player1Dices = players.First().Dices;
            var player2Dices = players.Last().Dices;
            var isNormalPoint = player1Dices.GroupBy(dice => dice.Value)
                .Count(grouping => grouping.Count() == 2) == 1;
            if (isNormalPoint)
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
                var winnerPlayer = compareResult2 > 0 ? players[0].Name : players[1].Name;

                var winnerCategory = "normal point";
                var winnerOutput = compareResult2 > 0 ? diceValuePlayer1.ToString() : diceValuePlayer2.ToString();
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }

            var player1Dice = player1Dices.First();
            var player2Dice = players[1].Dices.First();

            var allOfAKindComparer = new AllOfAKindComparer();
            var compareResult = allOfAKindComparer.CompareResult(player1Dice, player2Dice);
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = allOfAKindComparer.WinnerCategoryName;
                return $"{winnerPlayer} win. - with {winnerCategory}: {allOfAKindComparer.WinnerOutput}";
            }

            return "Tie.";
        }
    }
}
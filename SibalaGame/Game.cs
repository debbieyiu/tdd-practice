using System.Linq;

namespace SibalaGame
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);

            var player1Dices = players[0].Dices;
            var player2Dices = players[1].Dices;

            var isNormalPoint = player1Dices.GroupBy(dice => dice.Value)
                .Count(grouping => grouping.Count() == 2) == 1;
            if (isNormalPoint)
            {
                var normalPointComparer = new NormalPointComparer();
                var compareResult2 = normalPointComparer.Compare(player1Dices, player2Dices, out var winnerOutput);

                var winnerPlayer = compareResult2 > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = "normal point";
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }

            var player1Dice = player1Dices.First();
            var player2Dice = players[1].Dices.First();

            var allOfAKindComparer = new AllOfAKindComparer();
            var compareResult = allOfAKindComparer.Compare(player1Dice, player2Dice);
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
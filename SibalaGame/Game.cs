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

            int compareResult;
            string winnerCategory;
            string winnerOutput;
            IComparer comparer;

            var isNormalPoint = player1Dices.GroupBy(dice => dice.Value)
                .Count(grouping => grouping.Count() == 2) >= 1;
            if (isNormalPoint)
            {
                comparer = new NormalPointComparer();
            }
            else
            {
                comparer = new AllOfAKindComparer();
            }

            compareResult = comparer.Compare(player1Dices, player2Dices);
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                winnerCategory = comparer.WinnerCategoryName;
                winnerOutput = comparer.WinnerOutput;
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
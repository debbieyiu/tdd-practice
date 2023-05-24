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

            var isNormalPoint = player1Dices.GroupBy(dice => dice.Value)
                .Count(grouping => grouping.Count() == 2) == 1;
            if (isNormalPoint)
            {
                IComparer normalPointComparer = new NormalPointComparer();
                compareResult = normalPointComparer.Compare(player1Dices, player2Dices);
                winnerCategory = normalPointComparer.WinnerCategoryName;
                winnerOutput = normalPointComparer.WinnerOutput;
            }
            else
            {
                IComparer allOfAKindComparer = new AllOfAKindComparer();
                compareResult = allOfAKindComparer.Compare(player1Dices, player2Dices);
                winnerCategory = allOfAKindComparer.WinnerCategoryName;
                winnerOutput = allOfAKindComparer.WinnerOutput;
            }

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
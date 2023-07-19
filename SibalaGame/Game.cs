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

            var comparer = new DicesComparer();
            var compareResult = comparer.Compare(player1Dices, player2Dices);
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                return $"{winnerPlayer} win. - with {comparer.WinnerCategory.Description}";
            }

            return "Tie.";
        }
    }
}
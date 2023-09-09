using System.Linq;

namespace SibalaGame
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);
            var dice1 = players[0].Dices.First();
            var dice2 = players[1].Dices.First();

            var compareResult = dice1.Value - dice2.Value;
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = "all of a kind";
                var winnerOutput = compareResult > 0 ? dice1.Output : dice2.Output;
                return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
            }

            return "Tie";
        }
    }
}
using System.Linq;

namespace SibalaGame
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);

            var winnerPlayer = players[0].Name;
            var winnerCategory = "all of a kind";
            var winnerOutput = players[0].Dices.First().Output;
            return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
        }
    }
}
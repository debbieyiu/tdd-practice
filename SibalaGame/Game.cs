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

            if ((int)(dice1.Value) > (int)(dice2.Value))
            {
                var winnerPlayer = players[0].Name;
                var winnerCategory = "all of a kind";
                var winnerOutput = players[0].Dices.First().Value.ToString();
                return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
            }
            else
            {
                var winnerPlayer = players[1].Name;
                var winnerCategory = "with all of a kind";
                var winnerOutput = players[1].Dices.First().Value.ToString();
                return $"{winnerPlayer} win. - {winnerCategory}: {winnerOutput}";
            }
        }
    }
}
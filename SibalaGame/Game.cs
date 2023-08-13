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

            string winnerPlayer;
            string winnerOutput;
            if (dice1.Value > dice2.Value)
            {
                winnerPlayer = players[0].Name;
                winnerOutput = players[0].Dices.First().Value.ToString();
            }
            else
            {
                winnerPlayer = players[1].Name;
                winnerOutput = players[1].Dices.First().Value.ToString();
            }

            var winnerCategory = "all of a kind";
            return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
        }
    }
}
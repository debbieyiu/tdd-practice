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
                string winnerPlayer;
                if (compareResult > 0)
                {
                    winnerPlayer = players[0].Name;
                }
                else
                {
                    winnerPlayer = players[1].Name;
                }

                string winnerOutput;
                if (compareResult > 0)
                {
                    winnerOutput = dice1.Output;
                }
                else
                {
                    winnerOutput = dice2.Output;
                }

                var winnerCategory = "all of a kind";
                return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
            }

            return "Tie";
        }
    }
}
using System.Linq;

namespace SibalaGame
{
    public class Game
    {
        public string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);

            var player1Dice = players[0].Dices.First();
            var player2Dice = players[1].Dices.First();

            if (player1Dice.Value > player2Dice.Value)
            {
                var winnerPlayer = players[0].Name;
                var winnerCategory = "all of a kind";
                var winnerOutput = player1Dice.Output;
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }
            else
            {
                var winnerPlayer = players[1].Name;
                var winnerCategory = "all of a kind";
                var winnerOutput = player2Dice.Output;
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }
        }
    }
}
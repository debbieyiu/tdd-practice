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

            if (player1Dice.Value == player2Dice.Value)
            {
                return "Tie.";
            }

            string winnerPlayer;
            string winnerOutput;
            if (player1Dice.Value > player2Dice.Value)
            {
                winnerPlayer = players[0].Name;
                winnerOutput = player1Dice.Output;
            }
            else
            {
                winnerPlayer = players[1].Name;
                winnerOutput = player2Dice.Output;
            }

            var winnerCategory = "all of a kind";
            return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
        }
    }
}
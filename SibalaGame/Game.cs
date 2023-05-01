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

            var compareResult = player1Dice.Value - player2Dice.Value;

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerOutput = compareResult > 0 ? player1Dice.Output : player2Dice.Output;

                var winnerCategory = "all of a kind";
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
using System;
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

            IComparer comparer;
            if (player1Dices.GetDicesCategory() != player2Dices.GetDicesCategory())
            {
                comparer = new DifferentCategoryComparer();
            }
            else
            {
                if (player1Dices.GetDicesCategory() == CategoryType.NormalPoint)
                {
                    comparer = new NormalPointComparer();
                }
                else
                {
                    comparer = new AllOfAKindComparer();
                }
            }

            var compareResult = comparer.Compare(player1Dices, player2Dices);
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = comparer.WinnerCategory.Name;
                var winnerOutput = comparer.WinnerCategory.Output;
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }
    }
}
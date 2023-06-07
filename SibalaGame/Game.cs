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

            int compareResult;
            string winnerCategory;
            string winnerOutput;
            IComparer comparer;

            var player1Category = GetDicesCategory(new Dices(player1Dices));
            var player2Category = GetDicesCategory(new Dices(player2Dices));

            if (player1Category != player2Category)
            {
                return "Black win. - with all of a kind: 5";
            }

            if (player1Category == Category.NormalPoint)
            {
                comparer = new NormalPointComparer();
            }
            else
            {
                comparer = new AllOfAKindComparer();
            }

            compareResult = comparer.Compare(player1Dices, player2Dices);
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                winnerCategory = comparer.WinnerCategoryName;
                winnerOutput = comparer.WinnerOutput;
                return $"{winnerPlayer} win. - with {winnerCategory}: {winnerOutput}";
            }

            return "Tie.";
        }

        private Category GetDicesCategory(Dices dices)
        {
            var groupBy = dices.GroupBy(dice => dice.Value).ToList();
            if (groupBy.Count(grouping => grouping.Count() == 4) == 1)
            {
                return Category.AllOfAKind;
            }

            if (groupBy.Count(grouping => grouping.Count() == 2) >= 1)
            {
                return Category.NormalPoint;
            }

            throw new NotImplementedException();
        }
    }
}
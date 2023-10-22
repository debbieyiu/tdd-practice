using System.Collections;
using System.Collections.Generic;

namespace SibalaGame
{
    public class Game : AllOfAKindComparer
    {
        public string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);
            var dices1 = players[0].Dices;
            var dices2 = players[1].Dices;

            if (dices1.CategoryType != dices2.CategoryType)
            {
                return "Black win with all of a kind: 5";
            }

            ICompare comparer;
            if (dices1.CategoryType == CategoryType.NormalPoint)
            {
                comparer = new NormalPointComparer();
            }
            else
            {
                comparer = new AllOfAKindComparer();
            }

            var compareResult = comparer.Compare(dices1, dices2);
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = comparer.WinnerCategoryDisplay;
                var winnerOutput = comparer.WinnerOutputDisplay;
                return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
            }

            return "Tie";
        }
    }
}
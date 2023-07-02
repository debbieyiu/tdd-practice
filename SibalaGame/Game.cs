﻿using System.Collections.Generic;
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
            if (player1Dices.GetCategory().Type != player2Dices.GetCategory().Type)
            {
                comparer = new DifferentCategoryComparer();
            }
            else
            {
                var sameCategoryComparerLookup = new Dictionary<CategoryType, IComparer>
                {
                    { CategoryType.AllOfAKind, new AllOfAKindComparer() },
                    { CategoryType.NormalPoint, new NormalPointComparer() },
                    { CategoryType.NoPoint, new NoPointComparer() },
                };

                comparer = sameCategoryComparerLookup[player1Dices.GetCategory().Type];
            }

            var compareResult = comparer.Compare(player1Dices, player2Dices);
            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                return $"{winnerPlayer} win. - with {comparer.WinnerCategory.Description}";
            }

            return "Tie.";
        }
    }
}
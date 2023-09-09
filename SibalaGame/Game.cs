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
            var dices1 = players[0].Dices;
            var dices2 = players[1].Dices;

            var compareResult = Compare(dices1, dices2, out var winnerOutput);

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = "all of a kind";
                return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
            }

            return "Tie";
        }

        private static int Compare(List<Dice> dices1, List<Dice> dices2, out string winnerOutput)
        {
            winnerOutput = null;
            var compareResult = dices1.First().Value - dices2.First().Value;
            if (compareResult != 0)
            {
                winnerOutput = compareResult > 0 ? dices1.First().Output : dices2.First().Output;
            }

            return compareResult;
        }
    }
}
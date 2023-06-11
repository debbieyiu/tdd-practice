﻿using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class NormalPointComparer : IComparer
    {
        public string WinnerCategoryName => "normal point";
        public string WinnerOutput { get; private set; }

        public int Compare(Dices player1Dices, Dices player2Dices)
        {
            var diceValuePlayer1 = player1Dices.CalculateNormalPointDices();
            var diceValuePlayer2 = player2Dices.CalculateNormalPointDices();
            var dicesPointPlayer1 = diceValuePlayer1.Sum(dice => dice.Value);
            var dicesPointPlayer2 = diceValuePlayer2.Sum(dice => dice.Value);

            var compareResult = dicesPointPlayer1 - dicesPointPlayer2;
            if (compareResult == 0)
            {
                compareResult = diceValuePlayer1.Max(dice => dice.Value) - diceValuePlayer2.Max(dice => dice.Value);
            }

            if (compareResult != 0)
            {
                WinnerOutput = compareResult > 0 ? dicesPointPlayer1.ToString() : dicesPointPlayer2.ToString();
            }

            return compareResult;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class AllOfAKindComparer
    {
        public int Compare(List<Dice> dices1, List<Dice> dices2, out string winnerOutput)
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
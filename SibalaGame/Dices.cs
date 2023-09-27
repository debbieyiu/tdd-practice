using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class Dices : List<Dice>
    {
        public Dices(IList<Dice> dices)
            : base(dices)
        {
        }

        public int GetDicesCompareValue()
        {
            var valueOrdering = new List<int> { 2, 3, 5, 6, 4, 1 };
            return valueOrdering.IndexOf(this.First().Value);
        }
    }
}
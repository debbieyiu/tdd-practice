using System.Collections.Generic;

namespace SibalaGame
{
    public class Dices : List<Dice>
    {
        public Dices(IList<Dice> dices)
            : base(dices)
        {
        }
    }
}
using System.Collections.Generic;

namespace SibalaGame
{
    public class Dices : List<Dice>
    {
        private readonly List<Dice> _dices;

        public Dices(IList<Dice> dices)
            : base(dices)
        {
        }
    }
}
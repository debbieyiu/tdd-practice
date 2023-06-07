using System.Collections;
using System.Collections.Generic;

namespace SibalaGame
{
    public class Dices : IEnumerable<Dice>
    {
        private readonly List<Dice> _dices;

        public Dices(List<Dice> dices)
        {
            _dices = dices;
        }

        public IEnumerator<Dice> GetEnumerator()
        {
            return _dices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
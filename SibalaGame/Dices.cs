using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class Dices : IEnumerable<Dice>
    {
        private readonly List<Dice> _dices;

        public Dices(List<Dice> dices)
        {
            _dices = dices;
        }

        public Category GetDicesCategory()
        {
            var groupBy = this.GroupBy(dice => dice.Value).ToList();
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
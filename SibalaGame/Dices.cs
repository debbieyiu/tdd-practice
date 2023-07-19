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

        public List<IGrouping<int, Dice>> DiceGrouping => this.GroupBy(dice => dice.Value).ToList();

        public List<Dice> CalculateNormalPointDices()
        {
            var minPairs = DiceGrouping
                .OrderBy(grouping => grouping.Key)
                .First(grouping => grouping.Count() == 2)
                .ToList();
            return this.Except(minPairs).ToList();
        }

        public Category GetCategory()
        {
            if (DiceGrouping.Count(grouping => grouping.Count() == 4) == 1)
            {
                return new AllOfAKind(this);
            }

            if (DiceGrouping.Count(grouping => grouping.Count() == 2) >= 1)
            {
                return new NormalPoint(this);
            }

            return new NoPoint();
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
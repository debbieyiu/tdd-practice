using System;
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

        public CategoryType CategoryType => GetCategoryType();

        private CategoryType GetCategoryType()
        {
            if (DiceGrouping.Count() == 4)
            {
                return CategoryType.NoPoint;
            }

            if (DiceGrouping.Count() > 1)
            {
                return CategoryType.NormalPoint;
            }

            return CategoryType.AllOfAKind;
        }

        public int GetCompareValue()
        {
            if (CategoryType == CategoryType.NormalPoint)
            {
                var pairDices = DiceGrouping
                    .OrderBy(grouping => grouping.Key)
                    .First(grouping => grouping.Count() == 2)
                    .ToList();
                return this.Except(pairDices).Sum(dice => dice.Value);
            }

            var valueOrdering = new List<int> { 2, 3, 5, 6, 4, 1 };
            return valueOrdering.IndexOf(this.First().Value);
        }

        private IEnumerable<IGrouping<int, Dice>> DiceGrouping => this.GroupBy(dice => dice.Value);

        public string GetOutputDisplay()
        {
            if (CategoryType == CategoryType.AllOfAKind)
            {
                return this.First().Value.ToString();
            }

            return GetCompareValue().ToString();
        }
    }
}
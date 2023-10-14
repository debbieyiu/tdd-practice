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
            if (this.GroupBy(dice => dice.Value).Count() > 1)
            {
                return CategoryType.NormalPoint;
            }

            return CategoryType.AllOfAKind;
        }

        public int GetCompareValue()
        {
            var valueOrdering = new List<int> { 2, 3, 5, 6, 4, 1 };
            return valueOrdering.IndexOf(this.First().Value);
        }
    }
}
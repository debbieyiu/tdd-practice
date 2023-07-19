using System.Collections.Generic;

namespace SibalaGame
{
    public class DicesComparer : IComparer
    {
        public Category WinnerCategory { get; set; }

        public int Compare(Dices dices1, Dices dices2)
        {
            IComparer comparer;
            if (dices1.GetCategory().Type != dices2.GetCategory().Type)
            {
                comparer = new DifferentCategoryComparer();
            }
            else
            {
                var sameCategoryComparerLookup = new Dictionary<CategoryType, IComparer>
                {
                    { CategoryType.AllOfAKind, new AllOfAKindComparer() },
                    { CategoryType.NormalPoint, new NormalPointComparer() },
                    { CategoryType.NoPoint, new NoPointComparer() },
                };

                comparer = sameCategoryComparerLookup[dices1.GetCategory().Type];
            }

            var compareResult = comparer.Compare(dices1, dices2);
            WinnerCategory = compareResult > 0 ? dices1.GetCategory() : dices2.GetCategory();
            return compareResult;
        }
    }
}
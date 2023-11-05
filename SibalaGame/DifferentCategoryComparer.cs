using System.ComponentModel.DataAnnotations;

namespace SibalaGame
{
    public class DifferentCategoryComparer : ICompare
    {
        public int Compare(Dices dices1, Dices dices2)
        {
            var compareResult = dices1.CategoryType - dices2.CategoryType;
            if (compareResult != 0)
            {
                WinnerCategoryDisplay = compareResult > 0
                    ? GetDisplayName(dices1.CategoryType)
                    : GetDisplayName(dices2.CategoryType);

                WinnerOutputDisplay = compareResult > 0
                    ? dices1.GetOutputDisplay()
                    : dices2.GetCompareValue().ToString();
            }
            return compareResult;
        }


        private string GetDisplayName(CategoryType category)
        {
            var type = typeof(CategoryType);
            var memberInfo = type.GetMember(category.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return ((DisplayAttribute)attributes[0]).Name;
        }

        public string WinnerCategoryDisplay { get; set; }

        public string WinnerOutputDisplay { get; set; }
    }
}
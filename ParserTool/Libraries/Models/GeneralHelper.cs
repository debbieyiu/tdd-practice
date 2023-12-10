using System;
using System.Linq;

namespace ParserTool.Libraries.Models
{
    public static class GeneralHelper
    {
        public static bool TryGetAttribute<TAttribute>(this Enum value, out TAttribute result)
            where TAttribute : Attribute
        {
            result = default(TAttribute);

            var enumType = value.GetType();
            var attribute = enumType.GetField(Enum.GetName(enumType, value)).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
            if (attribute != null)
            {
                result = attribute;
                return true;
            }

            return false;
        }
    }
}
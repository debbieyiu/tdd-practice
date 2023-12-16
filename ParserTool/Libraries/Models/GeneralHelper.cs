using System;
using System.Linq;
using System.Xml;

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

        public static bool TryGetAttribute(this XmlNode value, string name, out string result)
        {
            result = null;

            var xmlAttributes = value.Attributes.Cast<XmlAttribute>();
            var matchingAttribute = xmlAttributes.FirstOrDefault(attribute => attribute.Name == name);
            if (matchingAttribute != null)
            {
                result = matchingAttribute.Value;
                return true;
            }

            return false;
        }
    }
}
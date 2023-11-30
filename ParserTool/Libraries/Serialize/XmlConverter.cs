using System.Xml;
using System.Xml.Serialization;

namespace ParserTool.Libraries.Serialize
{
    public class XmlConverter
    {
        public static T DeserializeObject<T>(string value)
        {
            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(value);
                var documentElement = xmlDocument.DocumentElement;

                return documentElement == null
                    ? default(T)
                    : (T)new XmlSerializer(typeof(T)).Deserialize(new XmlNodeReader(documentElement));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
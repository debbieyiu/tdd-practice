using Newtonsoft.Json;

namespace ParserTool.Libraries.Serialize
{
    public class JsonConverter
    {
        public static T DeserializeObject<T>(string value) => JsonConvert.DeserializeObject<T>(value);
    }
}
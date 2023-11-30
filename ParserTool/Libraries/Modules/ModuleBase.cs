using System.IO;
using System.Web;
using System.Web.Caching;
using ParserTool.Libraries.Serialize;

namespace ParserTool.Libraries.Modules
{
    public abstract class ModuleBase<T, THelper> : Singleton<THelper> where T : class where THelper : ModuleBase<T, THelper>
    {
        private const string CacheValue = "dummy";
        private T _config;

        public T Config
        {
            get
            {
                Parser();
                return _config;
            }
        }

        protected virtual ConfigType ConfigType => ConfigType.Json;

        private void Parser()
        {
            var moduleKey = typeof(T).FullName ?? string.Empty;
            if (HttpContext.Current.Cache[moduleKey] == null || _config == null)
            {
                var configFile = GetConfigFilePath();
                var fullName = HttpContext.Current.Server.MapPath(configFile);

                var configContent = File.ReadAllText(fullName);

                // Deserialize JSON to objects.
                _config = DeserializeConfigContent(configContent);

                HttpContext.Current.Cache.Insert(moduleKey, CacheValue, new CacheDependency(fullName));
            }
        }

        protected abstract string GetConfigFilePath();

        private T DeserializeConfigContent(string configContent)
        {
            return ConfigType == ConfigType.Xml
                ? XmlConverter.DeserializeObject<T>(configContent)
                : JsonConverter.DeserializeObject<T>(configContent);
        }
    }
}
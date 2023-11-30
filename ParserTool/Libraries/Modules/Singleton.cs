using System;

namespace ParserTool.Libraries.Modules
{
    public abstract class Singleton<T> where T : class
    {
        protected static readonly Lazy<T> LazyInstance;

        public static T Instance => LazyInstance.Value;

        static Singleton()
        {
            LazyInstance = new Lazy<T>(() =>
                Activator.CreateInstance(typeof(T), true) as T
            );
        }
    }
}
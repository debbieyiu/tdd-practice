namespace SibalaGame
{
    public abstract class Category
    {
        public abstract string Name { get; }
        public abstract string Output { get; }
        public abstract CategoryType Type { get; }
        public string Description => $"{Name}: {Output}";
    }
}
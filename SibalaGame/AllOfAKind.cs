using System.Linq;

namespace SibalaGame
{
    public class AllOfAKind : Category
    {
        public AllOfAKind(Dices dices)
        {
            Output = dices.First().Output;
        }

        public override string Name => "all of a kind";
        public override string Output { get; }
    }
}
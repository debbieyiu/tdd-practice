using System.Linq;

namespace SibalaGame
{
    public class NormalPoint : Category
    {
        public NormalPoint(Dices dices)
        {
            Output = dices.CalculateNormalPointDices()
                .Sum(dice => dice.Value)
                .ToString();
        }

        public override string Name => "normal point";
        public override string Output { get; }
        public override CategoryType Type => CategoryType.NormalPoint;
    }
}
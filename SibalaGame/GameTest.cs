using FluentAssertions;
using NUnit.Framework;

namespace SibalaGame
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void A01_BothAllOfAKind()
        {
            var target = new Game();
            var actual = target.ShowResult("Black: 5 5 5 5  White: 2 2 2 2");
            actual.Should().Be("Black win. - with all of a kind: 5");
        }
    }
}
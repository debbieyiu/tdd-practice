using FluentAssertions;
using NUnit.Framework;

namespace SibalaGame
{
    [TestFixture]
    public class GameTest
    {
        private Game _target;

        [SetUp]
        public void @Setup()
        {
            _target = new Game();
        }

        [Test]
        public void A01_BothAllOfAKind()
        {
            AssertShowResultShouldReturn("Black: 5 5 5 5  White: 2 2 2 2", "Black win. - with all of a kind: 5");
        }

        private void AssertShowResultShouldReturn(string input, string expected)
        {
            var actual = _target.ShowResult(input);
            actual.Should().Be(expected);
        }
    }
}
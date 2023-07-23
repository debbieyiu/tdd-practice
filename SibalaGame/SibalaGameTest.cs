using FluentAssertions;
using NUnit.Framework;

namespace SibalaGame
{
    [TestFixture]
    public class SibalaGameTest
    {
        private Game _target;

        [SetUp]
        public void @Setup()
        {
            _target = new Game();
        }

        [Test]
        public void A01_Both_AllOfAKind()
        {
            var input = "Black: 5 5 5 5  White: 2 2 2 2";
            var actual = _target.ShowResult(input);
            actual.Should().Be("Black win with all of a kind: 5");
        }
    }
}
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
        [TestCase("Black: 5 5 5 5  White: 2 2 2 2", "Black win with all of a kind: 5")]
        [TestCase("Black: 3 3 3 3  White: 6 6 6 6", "White win with all of a kind: 6")]
        [TestCase("Black: 3 3 3 3  White: 3 3 3 3", "Tie")]
        public void A01_Both_AllOfAKind(string input, string expected)
        {
            AssertShowResultShouldReturn(input, expected);
        }

        private void AssertShowResultShouldReturn(string input, string expected)
        {
            var actual = _target.ShowResult(input);
            actual.Should().Be(expected);
        }
    }
}
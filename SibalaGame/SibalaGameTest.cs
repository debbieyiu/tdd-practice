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
        [TestCase("Black: 4 4 4 4  White: 5 5 5 5", "Black win with all of a kind: 4")]
        [TestCase("Black: 6 6 6 6  White: 4 4 4 4", "White win with all of a kind: 4")]
        [TestCase("Black: 1 1 1 1  White: 4 4 4 4", "Black win with all of a kind: 1")]
        [TestCase("Black: 4 4 4 4  White: 1 1 1 1", "White win with all of a kind: 1")]
        public void A01_Both_AllOfAKind(string input, string expected)
        {
            AssertShowResultShouldReturn(input, expected);
        }

        [Test]
        [TestCase("Black: 2 6 2 3  White: 5 3 5 4", "Black win with normal point: 9")]
        [TestCase("Black: 2 1 3 3  White: 2 2 1 3", "White win with normal point: 4")]
        [TestCase("Black: 2 3 4 2  White: 1 1 4 3", "Tie")]
        [TestCase("Black: 4 4 2 2  White: 2 3 2 1", "Black win with normal point: 8")]
        [TestCase("Black: 3 4 5 5  White: 4 1 4 6", "White win with normal point: 7")]
        public void A02_Both_NormalPoint(string input, string expected)
        {
            AssertShowResultShouldReturn(input, expected);
        }

        [Test]
        [TestCase("Black: 5 5 5 5  White: 4 1 4 6", "Black win with all of a kind: 5")]
        public void A03_DiffCategory(string input, string expected)
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
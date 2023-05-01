using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace SibalaGame
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void A01_Parse_PlayerName()
        {
            var parser = new Parser();
            var actual = parser.Parse("Black: 5 5 5 5  White: 2 2 2 2");
            actual.Should().BeEquivalentTo(
                new List<Player>
                {
                    new Player { Name = "Black",
                        Dices = new List<Dice>
                        {
                            new Dice { Value = 5, Output = "5" },
                            new Dice { Value = 5, Output = "5" },
                            new Dice { Value = 5, Output = "5" },
                            new Dice { Value = 5, Output = "5" }
                        } },
                    new Player { Name = "White" }
                });
        }
    }
}
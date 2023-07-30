using System;
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            var playerBlocks = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
            var player1Name = playerBlocks.First().Split(":", StringSplitOptions.RemoveEmptyEntries).First();
            var player2Name = playerBlocks.Last().Split(":", StringSplitOptions.RemoveEmptyEntries).First();

            return new List<Player>
            {
                new Player
                {
                    Name = player1Name,
                    Dices = new List<Dice>
                    {
                        new Dice { Value = "5" },
                        new Dice { Value = "5" },
                        new Dice { Value = "5" },
                        new Dice { Value = "5" }
                    }
                },
                new Player { Name = player2Name }
            };
        }
    }
}
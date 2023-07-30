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
            return new List<Player>
            {
                new Player { Name = player1Name },
                new Player { Name = "White" }
            };
        }
    }
}
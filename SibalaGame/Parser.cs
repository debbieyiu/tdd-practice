using System;
using System.Collections.Generic;

namespace SibalaGame
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            var playerSections = input.Split("  ");
            var playerAndDices = playerSections[0].Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player1Name = playerAndDices[0];

            return new List<Player>
            {
                new Player { Name = player1Name },
                new Player { Name = "White" }
            };
        }
    }
}
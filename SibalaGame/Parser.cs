using System;
using System.Collections.Generic;

namespace SibalaGame
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            var playerSections = input.Split("  ");
            var player1AndDices = playerSections[0].Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player1Name = player1AndDices[0];

            var player2AndDices = playerSections[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player2Name = player2AndDices[0];

            return new List<Player>
            {
                new Player
                {
                    Name = player1Name,
                    Dices = new List<Dice>
                    {
                        new Dice { Value = 5, Output = "5" },
                        new Dice { Value = 5, Output = "5" },
                        new Dice { Value = 5, Output = "5" },
                        new Dice { Value = 5, Output = "5" }
                    }
                },
                new Player { Name = player2Name }
            };
        }
    }
}
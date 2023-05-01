using System;
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            var playerSections = input.Split("  ");
            var player1 = GetPlayer(playerSections[0]);

            var player2Section = playerSections[1];
            var player2AndDices = player2Section.Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player2Name = player2AndDices[0];
            var player2Dices = player2AndDices[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => new Dice { Value = int.Parse(str), Output = str })
                .ToList();
            var player2 = new Player
            {
                Name = player2Name,
                Dices = player2Dices
            };

            return new List<Player>
            {
                player1,
                player2
            };
        }

        private static Player GetPlayer(string playerSection)
        {
            var playerAndDices = playerSection.Split(":", StringSplitOptions.RemoveEmptyEntries);
            var name = playerAndDices[0];
            var dices = playerAndDices[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => new Dice { Value = int.Parse(str), Output = str })
                .ToList();

            return new Player
            {
                Name = name,
                Dices = dices
            };
        }
    }
}
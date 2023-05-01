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
            var player2 = GetPlayer(playerSections[1]);

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
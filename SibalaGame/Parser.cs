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
            var player1 = GetPlayer(playerBlocks, 0);
            var player2 = GetPlayer(playerBlocks, 1);
            return new List<Player>
            {
                player1,
                player2
            };
        }

        private static Player GetPlayer(string[] playerBlocks, int index)
        {
            var player1Block = playerBlocks[index].Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player1Name = player1Block.First();
            var player1Dices = player1Block.Last()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new Dice { Value = s })
                .ToList();
            var player1 = new Player
            {
                Name = player1Name,
                Dices = player1Dices
            };
            return player1;
        }
    }
}
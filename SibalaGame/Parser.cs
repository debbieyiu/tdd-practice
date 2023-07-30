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
            var player1Block = playerBlocks.First().Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player1Name = player1Block.First();
            var player1Dices = player1Block.Last()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new Dice { Value = s })
                .ToList();
            var player2Block = playerBlocks.Last().Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player2Name = player2Block.First();
            var player2Dices = player2Block.Last()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new Dice { Value = s })
                .ToList();

            var player1 = new Player
            {
                Name = player1Name,
                Dices = player1Dices
            };
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
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            var playerBlocks = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
            return new List<Player>
            {
                GetPlayer(playerBlocks, 0),
                GetPlayer(playerBlocks, 1)
            };
        }

        private static Player GetPlayer(string[] playerBlocks, int index)
        {
            var player1Block = playerBlocks[index].Split(":", StringSplitOptions.RemoveEmptyEntries);
            return new Player
            {
                Name = player1Block.First(),
                Dices = new Dices(player1Block.Last()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => new Dice { Value = int.Parse(s), Output = s })
                    .ToList())
            };
        }
    }
}
﻿using System;
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
            var player2Name = playerBlocks.Last().Split(":", StringSplitOptions.RemoveEmptyEntries).First();

            return new List<Player>
            {
                new Player
                {
                    Name = player1Name,
                    Dices = player1Dices
                },
                new Player { Name = player2Name }
            };
        }
    }
}
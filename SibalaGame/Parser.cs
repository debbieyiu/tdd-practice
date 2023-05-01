﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SibalaGame
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            var playerSections = input.Split("  ");
            var player1AndDices = playerSections[0].Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player1Name = player1AndDices[0];
            var player1Dices = player1AndDices[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => new Dice { Value = int.Parse(str), Output = str })
                .ToList();

            var player2AndDices = playerSections[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
            var player2Name = player2AndDices[0];

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
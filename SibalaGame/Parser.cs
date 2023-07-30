using System.Collections.Generic;

namespace SibalaGame
{
    public class Parser
    {
        public List<Player> Parse(string input)
        {
            return new List<Player>
            {
                new Player { Name = "Black" },
                new Player { Name = "White" }
            };
        }
    }
}
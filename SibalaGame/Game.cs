namespace SibalaGame
{
    public class Game : AllOfAKindComparer
    {
        public string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);
            var dices1 = players[0].Dices;
            var dices2 = players[1].Dices;

            var allOfAKindComparer = new AllOfAKindComparer();
            var compareResult = allOfAKindComparer.Compare(dices1, dices2, out var winnerOutput);

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = "all of a kind";
                return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
            }

            return "Tie";
        }
    }
}
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

            if (dices1.CategoryType == CategoryType.NormalPoint)
            {
                return "Black win with normal point: 9";
            }

            var allOfAKindComparer = new AllOfAKindComparer();
            var compareResult = allOfAKindComparer.Compare(dices1, dices2);

            if (compareResult != 0)
            {
                var winnerPlayer = compareResult > 0 ? players[0].Name : players[1].Name;
                var winnerCategory = allOfAKindComparer.WinnerCategoryDisplay;
                var winnerOutput = allOfAKindComparer.WinnerOutputDisplay;
                return $"{winnerPlayer} win with {winnerCategory}: {winnerOutput}";
            }

            return "Tie";
        }
    }
}
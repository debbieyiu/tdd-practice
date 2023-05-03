namespace SibalaGame
{
    public class AllOfAKindComparer
    {
        public string WinnerCategoryName => "all of a kind";

        public int CompareResult(Dice player1Dice, Dice player2Dice, out string winnerOutput)
        {
            winnerOutput = string.Empty;
            var compareResult = player1Dice.Value - player2Dice.Value;
            if (compareResult != 0)
            {
                winnerOutput = compareResult > 0 ? player1Dice.Output : player2Dice.Output;
            }

            return compareResult;
        }
    }
}
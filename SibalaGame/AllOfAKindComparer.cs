namespace SibalaGame
{
    public class AllOfAKindComparer
    {
        public string WinnerCategoryName => "all of a kind";

        public string WinnerOutput { get; private set; }

        public int CompareResult(Dice player1Dice, Dice player2Dice)
        {
            var compareResult = player1Dice.Value - player2Dice.Value;
            if (compareResult != 0)
            {
                WinnerOutput = compareResult > 0 ? player1Dice.Output : player2Dice.Output;
            }

            return compareResult;
        }
    }
}
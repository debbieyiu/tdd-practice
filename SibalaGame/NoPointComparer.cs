namespace SibalaGame
{
    public class NoPointComparer : IComparer
    {
        public Category WinnerCategory => new NoPoint();

        public int Compare(Dices dices1, Dices dices2)
        {
            return 0;
        }
    }
}
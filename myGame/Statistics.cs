namespace myGame
{
    public class GameStatistics
    {
        public int Attempts { get; private set; }

        public void AddAttempt()
        {
            Attempts++;
        }
    }
}
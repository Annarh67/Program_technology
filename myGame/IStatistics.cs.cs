namespace myGame
{
    public interface IStatistics
    {
        int Attempts { get; }

        void AddAttempt();
    }
}
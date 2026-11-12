
namespace myGame

{
    public class Statistics : IStatistics
    {
        public int Attempts { get; private set; }

        public void AddAttempt()
        {
            Attempts++;
        }
    }
}
using System.IO;
using System;
namespace myGame

{
    public class GameStatistics
    {
        public int Attempts { get; private set; }

        public void AddAttempt()
        {
            Attempts++;
        }
        public void SaveToFile(Levels level)
        {
            File.AppendAllText("statistics.txt",
                "Уровень: " + level + ", попыток: " + Attempts + Environment.NewLine);
        }
    }
}
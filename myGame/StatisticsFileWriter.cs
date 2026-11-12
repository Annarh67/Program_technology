using System;
using System.IO;

namespace myGame
{
    public class StatisticsFileWriter
    {
        public void SaveToFile(Levels level, int attempts)
        {
            File.AppendAllText("statistics.txt",
                "Уровень: " + level +
                ", попыток: " + attempts +
                Environment.NewLine);
        }
    }
}
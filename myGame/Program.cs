
using System;

namespace myGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1 - Легкий (1-50)");
            Console.WriteLine("2 - Средний (1-100)");
            Console.WriteLine("3 - Сложный (1-333)");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice)
                   || choice < 1 || choice > 3)
            {
                Console.WriteLine("Введите число от 1 до 3:");
            }

            Levels level = (Levels)choice;

            Console.WriteLine("Показывать подсказки?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("2 - Нет");

            int hintsChoice;

            while (!int.TryParse(Console.ReadLine(), out hintsChoice)
                   || hintsChoice < 1 || hintsChoice > 2)
            {
                Console.WriteLine("Введите число от 1 до 2:");
            }

            Settings settings = new Settings();
            settings.ShowHints = hintsChoice == 1;

            INumberGenerator generator = new NumberGenerator();
            //INumberGenerator generator = new TestNumberGenerator(); //LSP принцип подстановки Лисков
            int maxNumber;

            if (level == Levels.Easy)
            {
                maxNumber = 50;
            }
            else if (level == Levels.Medium)
            {
                maxNumber = 100;
            }
            else
            {
                maxNumber = 333;
            }
            Game game = new Game(generator, 1, maxNumber);
            game.GameWon += ShowWinMessage;
            game.GuessMade += ShowGuessMessage;
            IStatistics statistics = new Statistics();
            StatisticsFileWriter fileWriter = new StatisticsFileWriter();

            int result = 1;

            Console.WriteLine("Игра началась!");

            while (result != 0)
            {
                Console.Write("Введите число: ");

                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("Введите целое число!");
                    continue;
                }

                result = game.CheckGuess(guess);
                statistics.AddAttempt();

                if (result == 0)
                {
                    Console.WriteLine("Количество попыток: " + statistics.Attempts);
                    fileWriter.SaveToFile(level, statistics.Attempts);
                }
                else if (settings.ShowHints)
                {
                    if (result == 1)
                    {
                        Console.WriteLine("Больше");
                    }
                    else
                    {
                        Console.WriteLine("Меньше");
                    }
                }
            }
        }
        static void ShowWinMessage()
        {
            Console.WriteLine("Поздравляем! Вы угадали число!");
        }
        static void ShowGuessMessage(int guess)
        {
            Console.WriteLine("Вы ввели число: " + guess);
        }
    }
}

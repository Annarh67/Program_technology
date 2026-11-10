
namespace myGame
{
    public class Game
    {
        private int number;

        public Game(NumberGenerator generator, Levels level)
        {
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

            number = generator.Generate(1, maxNumber);
        }

        public int CheckGuess(int guess)
        {
            if (guess < number)
            {
                return 1;
            }
            else if (guess > number)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}

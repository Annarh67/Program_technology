
namespace myGame
{
    public class Game
    {
        private int number;

        public Game(NumberGenerator generator)
        {
            number = generator.Generate(1, 100);
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

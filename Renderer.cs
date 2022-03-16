using static System.Console;

namespace Pacman
{
    class Renderer
    {
        public void PrintPlayer(int positionX, int positionY)
        {
            SetCursorPosition(positionX, positionY);
            Write(Constants.PLAYER);
        }

        public void PrintWorld(string element, int mazePositionY, int mazePositionX)
        {
            SetCursorPosition(mazePositionY, mazePositionX);
            Write(element);
        }

        public void PrintEnemy(int enemyCursorX, int enemyCursorY)
        {
            SetCursorPosition(enemyCursorX, enemyCursorY);
            Write(Constants.ENEMY);
        }

        public void PrintCoin(int coins)
        {
            SetCursorPosition(0, 20);
            Write("Score: ");
            Write(coins);
        }

        public void PrintOnBoarding()
        {
            Title = ">>>Pacman<<<";
            Clear();
            WriteLine(AsciiArt.TEXT_PACMAN);
            WriteLine("");
            WriteLine("Hello there!!! Here is Pacmaaaan!");
            WriteLine("");
            WriteLine("");
            Write("Press any key to START!");
            ReadKey();
            Clear();
        }

        public void PrintGameOver(int finalScore)
        {
            Clear();
            WriteLine(AsciiArt.TEXT_GAMEOVER);
            PrintText(finalScore);
        }

        public void PrintWin(int finalScore)
        {
            Clear();
            WriteLine(AsciiArt.TEXT_YOUWIN);
            PrintText(finalScore);
        }

        private void PrintText(int finalScore)
        {
            WriteLine("");
            WriteLine("Your score is " + finalScore + ".");
            WriteLine("");
            WriteLine("Press ENTER to restart or ESCAPE to exit...");
        }
    }
}
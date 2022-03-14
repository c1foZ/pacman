using System;
using System.Threading;
namespace pacman
{
    class Game
    {
        PlayerMovement pm = new PlayerMovement();
        public void GameManager()
        {
            printOnBoarding();
            pm.movePlayer();
        }

        public void printOnBoarding()
        {
            Console.Title = ">>>Pacman<<<";
            Console.Clear();
            Console.WriteLine(@"
               ▄███████▄    ▄████████  ▄████████   ▄▄▄▄███▄▄▄▄      ▄████████ ███▄▄▄▄   
              ███    ███   ███    ███ ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███ ███▀▀▀██▄ 
              ███    ███   ███    ███ ███    █▀  ███   ███   ███   ███    ███ ███   ███ 
              ███    ███   ███    ███ ███        ███   ███   ███   ███    ███ ███   ███ 
            ▀█████████▀  ▀███████████ ███        ███   ███   ███ ▀███████████ ███   ███ 
              ███          ███    ███ ███    █▄  ███   ███   ███   ███    ███ ███   ███ 
              ███          ███    ███ ███    ███ ███   ███   ███   ███    ███ ███   ███ 
             ▄████▀        ███    █▀  ████████▀   ▀█   ███   █▀    ███    █▀   ▀█   █▀  

            ");
            Console.WriteLine("");
            Console.WriteLine("Hello there!!! Here is Pacmaaaan!");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Press any key to START!");

            Console.ReadKey();
            Console.Clear();
        }

        public void printGameOver(int finalScore)
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(@"
                     ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
                    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
                    ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
                    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
                    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
                    ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝                                                                          
                    ");
            Console.WriteLine("");
            Console.WriteLine("Your score is " + finalScore + ".");
            Console.WriteLine("");
            Thread.Sleep(2000);
            Console.WriteLine("Press ENTER to restart or ESCAPE to exit...");

            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        restartGame();
                        break;
                    case ConsoleKey.Escape:
                        quitGame();
                        break;
                }
            }
        }

        public void printWin(int finalScore)
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(@"
██    ██  ██████  ██    ██     ██     ██ ██ ███    ██ ██ ██ ██ 
 ██  ██  ██    ██ ██    ██     ██     ██ ██ ████   ██ ██ ██ ██ 
  ████   ██    ██ ██    ██     ██  █  ██ ██ ██ ██  ██ ██ ██ ██ 
   ██    ██    ██ ██    ██     ██ ███ ██ ██ ██  ██ ██          
   ██     ██████   ██████       ███ ███  ██ ██   ████ ██ ██ ██ 
                    ");
            Console.WriteLine("");
            Console.WriteLine("Your score is " + finalScore + ".");
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.WriteLine("Congratulations!!!");
            Console.WriteLine("");
            Thread.Sleep(2000);
            Console.WriteLine("Press ENTER to restart or ESCAPE to exit...");

            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        restartGame();
                        break;
                    case ConsoleKey.Escape:
                        quitGame();
                        break;
                }
            }
        }
        void restartGame()
        {
            PlayerMovement pm = new PlayerMovement();
            pm.movePlayer();
        }

        void quitGame()
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }
}

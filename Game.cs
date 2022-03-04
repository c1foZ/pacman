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
            Thread.Sleep(3000);
            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}

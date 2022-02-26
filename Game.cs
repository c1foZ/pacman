using System;
using static System.Console;

namespace pacman
{
    class Game
    {
        public void printOnBoarding()
        {
            Title = ">>>Pacman<<<";
            Clear();
            WriteLine(@"
               ▄███████▄    ▄████████  ▄████████   ▄▄▄▄███▄▄▄▄      ▄████████ ███▄▄▄▄   
              ███    ███   ███    ███ ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███ ███▀▀▀██▄ 
              ███    ███   ███    ███ ███    █▀  ███   ███   ███   ███    ███ ███   ███ 
              ███    ███   ███    ███ ███        ███   ███   ███   ███    ███ ███   ███ 
            ▀█████████▀  ▀███████████ ███        ███   ███   ███ ▀███████████ ███   ███ 
              ███          ███    ███ ███    █▄  ███   ███   ███   ███    ███ ███   ███ 
              ███          ███    ███ ███    ███ ███   ███   ███   ███    ███ ███   ███ 
             ▄████▀        ███    █▀  ████████▀   ▀█   ███   █▀    ███    █▀   ▀█   █▀  

            ");
            WriteLine("");
            WriteLine("Hello there!!! Here is Pacmaaaan!");
            WriteLine("");
            WriteLine("");
            Write("Press any key to START!");

            ReadKey();
            Clear();
        }
    }
}
using System;
using static System.Console;

namespace pacman
{
    class GameOver
    {
        public void printOnGameOver()
        {
            Title = ">>>Pacman<<<";
            Clear();
            WriteLine(@"
        
  ______                       _____                   
 / _____)                     / ___ \                  
| /  ___  ____ ____   ____   | |   | |_   _ ____  ____ 
| | (___)/ _  |    \ / _  )  | |   | | | | / _  )/ ___)
| \____/( ( | | | | ( (/ /   | |___| |\ V ( (/ /| |    
 \_____/ \_||_|_|_|_|\____)   \_____/  \_/ \____)_|    
                                                       
            ");
            WriteLine("");
            WriteLine("");
            Write("Thanks for playing!");

            ReadKey();
        }
    }
}
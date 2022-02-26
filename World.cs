using System;
using static System.Console;

namespace pacman
{
    class World
    {
        public void DrawWorld()
        {
            string[,] maze = {
                {"=","=","=","=","=","=","=","=","=","=","=","="},
                {"|"," "," "," "," ","|"," ","|"," ","|","X","|"},
                {"|"," "," ","|"," ","|"," "," "," ","|"," ","|"},
                {"|","0"," ","|"," "," "," ","|"," "," "," ","|"},
                {"=","=","=","=","=","=","=","=","=","=","=","="},
            };
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    string element = maze[i, j];
                    SetCursorPosition(j, i);
                    Write(element);
                }
            }
            WriteLine("");
        }
    }
}

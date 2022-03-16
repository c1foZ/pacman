using System;

namespace Pacman
{
    class World
    {
        public string[,] maze =  {
                {Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.W},
                {Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.W,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W,Constants.O,Constants.S,Constants.W,Constants.O,Constants.S,Constants.S,Constants.W,Constants.S,Constants.O,Constants.S,Constants.S,Constants.W},
                {Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W,Constants.W},
            };

        public void RenderWorld()
        {
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    string element = maze[i, j];
                    Console.SetCursorPosition(j, i);
                    Console.Write(element);
                }
            }
        }
    }
}

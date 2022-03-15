using System;
namespace pacman
{
    class World
    {
        const string w = "■";
        const string s = "\u2009";
        const string o = ".";
        public string W
        {
            get { return w; }
            private set { }
        }
        public string S
        {
            get { return s; }
            private set { }
        }
        public string O
        {
            get { return o; }
            private set { }
        }
        public string[,] maze =  {
                {w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w},
                {w,s,o,s,s,w,s,w,s,w,s,s,s,s,s,s,s,w,s,w,s,w,s,o,w},
                {w,s,s,w,s,w,s,o,s,w,s,s,w,s,s,w,s,w,s,o,s,w,s,s,w},
                {w,o,s,w,o,s,s,w,s,o,s,s,w,o,s,w,o,s,s,w,s,o,s,s,w},
                {w,s,o,s,s,w,s,w,s,w,s,s,s,s,s,s,s,w,s,w,s,w,s,o,w},
                {w,s,s,w,s,w,s,o,s,w,s,s,w,s,s,w,s,w,s,o,s,w,s,s,w},
                {w,o,s,w,o,s,s,w,s,o,s,s,w,o,s,w,o,s,s,w,s,o,s,s,w},
                {w,s,o,s,s,w,s,w,s,w,s,s,s,s,s,s,s,w,s,w,s,w,s,o,w},
                {w,s,s,w,s,w,s,o,s,w,s,s,w,s,s,w,s,w,s,o,s,w,s,s,w},
                {w,o,s,w,o,s,s,w,s,o,s,s,w,o,s,w,o,s,s,w,s,o,s,s,w},
                {w,s,o,s,s,w,s,w,s,w,s,s,s,s,s,s,s,w,s,w,s,w,s,o,w},
                {w,s,s,w,s,w,s,o,s,w,s,s,w,s,s,w,s,w,s,o,s,w,s,s,w},
                {w,o,s,w,o,s,s,w,s,o,s,s,w,o,s,w,o,s,s,w,s,o,s,s,w},
                {w,s,o,s,s,w,s,w,s,w,s,s,s,s,s,s,s,w,s,w,s,w,s,o,w},
                {w,s,s,w,s,w,s,o,s,w,s,s,w,s,s,w,s,w,s,o,s,w,s,s,w},
                {w,o,s,w,o,s,s,w,s,o,s,s,w,o,s,w,o,s,s,w,s,o,s,s,w},
                {w,s,o,s,s,w,s,w,s,w,s,s,s,s,s,s,s,w,s,w,s,w,s,o,w},
                {w,s,s,w,s,w,s,o,s,w,s,s,w,s,s,w,s,w,s,o,s,w,s,s,w},
                {w,o,s,w,o,s,s,w,s,o,s,s,w,o,s,w,o,s,s,w,s,o,s,s,w},
                {w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w,w},
            };
        public void renderWorld()
        {
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);
            DrawWorld();

            void DrawWorld()
            {

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
}

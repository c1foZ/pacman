using System;
using System.Threading;
using System.Threading.Tasks;

namespace pacman
{
    class Program
    {
        const string W = "#";
        const string S = " ";
        const string PLAYER = "*";
        const string o = ".";
        const int maxRight = 23;
        const int maxDown = 18;
        static void Main(string[] args)
        {
            // Game game = new Game();
            // World world = new World();
            // PlayerMovement movement = new PlayerMovement();

            // game.printOnBoarding();
            // movement.movePlayer();
            Console.Clear();
            int x = 1, y = 1;
            Move(PLAYER);
            string[,] maze = {
                {W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,S,o,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,o,W},
                {W,S,S,W,S,W,S,o,S,W,S,S,W,S,S,W,S,W,S,o,S,W,S,S,W},
                {W,o,S,W,o,S,S,W,S,o,S,S,W,o,S,W,o,S,S,W,S,o,S,S,W},
                {W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W},
            };
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);
            int coins = 0;
            DrawWorld();
            Move(PLAYER, x, y);

<<<<<<< HEAD
=======


>>>>>>> f98cc6676c6ada1e4fe595911e72488f81db56f4
            while (true)
            {
                Console.CursorVisible = false;
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            if (maze[y + 1, x] != W)
                            {
                                y++;
                                Play();
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (maze[y - 1, x] != W)
                            {
                                y--;
                                Play();
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (maze[y, x - 1] != W)
                            {
                                x--;
                                Play();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (maze[y, x + 1] != W)
                            {
                                x++;
                                Play();
                            }
                            break;
                    }
                }
            }

            void Play()
            {
                DrawWorld();
                Move(PLAYER, x, y);
                GetCoin();
            }

            void GetCoin()
            {
                if (maze[y, x] == o)
                {
                    maze[y, x] = S;
                    coins += 1;
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(coins);
                }
            }

            void Move(string PLAYER, int x = 1, int y = 1)
            {
                if (x >= 1 && y >= 1 && x <= maxRight && y <= maxDown)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(PLAYER);
                }
            }

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

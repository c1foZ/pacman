using System;
using System.Runtime.InteropServices;
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
        const int maxDown = 3;
        const int timeout = 333;
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
                {W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W},
            };
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);
            int coins = 0;
            DrawWorld();
            Move(PLAYER, x, y);
            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var stepMs = 333;
            long now;
            var i = 0;
            ConsoleKey? lastKeyPress = null;


            while (true)
            {
                Console.CursorVisible = false;
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey(false).Key;
                    lastKeyPress = command;
                    now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (now - startTime <= stepMs)
                    {
                        continue;
                    }
                    startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (lastKeyPress != null)
                    {
                        Console.SetCursorPosition(50, 20);
                        System.Console.WriteLine("last press: " + lastKeyPress);
                        lastKeyPress = null;
                    }

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            while (y < maxDown && maze[y + 1, x] != W)
                            {
                                now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (now - startTime <= stepMs)
                                {
                                    continue;
                                }
                                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (lastKeyPress != null)
                                {
                                    Console.SetCursorPosition(50, 50);
                                    System.Console.WriteLine("last press: " + lastKeyPress);
                                    lastKeyPress = null;
                                }
                                y++;
                                Play();
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            while (y > 1 && maze[y - 1, x] != W)
                            {
                                now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (now - startTime <= stepMs)
                                {
                                    continue;
                                }
                                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (lastKeyPress != null)
                                {
                                    Console.SetCursorPosition(50, 50);
                                    System.Console.WriteLine("last press: " + lastKeyPress);
                                    lastKeyPress = null;
                                }

                                y--;
                                Play();
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            while (x > 1 && maze[y, x - 1] != W)
                            {
                                now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (now - startTime <= stepMs)
                                {
                                    continue;
                                }
                                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (lastKeyPress != null)
                                {
                                    Console.SetCursorPosition(50, 50);
                                    System.Console.WriteLine("last press: " + lastKeyPress);
                                    lastKeyPress = null;
                                }
                                x--;
                                Play();
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            while (x < maxRight && maze[y, x + 1] != W)
                            {
                                now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (now - startTime <= stepMs)
                                {
                                    continue;
                                }
                                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                if (lastKeyPress != null)
                                {
                                    Console.SetCursorPosition(50, 50);
                                    System.Console.WriteLine("last press: " + lastKeyPress);
                                    lastKeyPress = null;
                                }
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
                // Thread.Sleep(timeout);
                ClearKeyBuffer();
                // ChangeDirection();
            }

            void ChangeDirection()
            {
                while (true)
                {
                    now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (now - startTime <= stepMs)
                    {
                        continue;
                    }
                    startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                }
            }

            void ClearKeyBuffer()
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
            }

            void GetCoin()
            {
                if (maze[y, x] == o)
                {
                    maze[y, x] = S;
                    coins += 1;
                    Console.SetCursorPosition(0, 5);
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

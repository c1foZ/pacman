using System;
using System.Collections.Generic;

namespace pacman
{
    class Program
    {
        const string W = "■";
        const string S = "\u2009";
        const string PLAYER = "◖";
        const string ENEMY = "☠";
        const string o = "."; 
        const int maxRight = 23;
        const int maxDown = 20;

        static void Main(string[] args)
        {
            while (true)
            {
                Game game = new Game();
                game.printOnBoarding();
                int playerX = 1, playerY = 1;
                int score = 0; 
                var random = new Random();

                var enemies = new List<(int x, int y)>
                {
                    (10, 10), // Enemy 1
                    (15, 5),  // Enemy 2
                    (20, 15), // Enemy 3
                    (15, 15), // Enemy 4
                    (15, 5),  // Enemy 5
                    (5, 5),   // Enemy 6
                    (1, 15),  // Enemy 7
                    (1, 10),  // Enemy 8
                    (10, 5),   // Enemy 9
                    (5, 1)    // Enemy 10
                };

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
                var direction = Direction.DOWN;

                void ResetLevel()
                {
                    playerX = 1;
                    playerY = 1;
                    score = 0;

                    maze = new string[,] {
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

                    enemies = new List<(int x, int y)>
                    {
                        (10, 10),
                        (15, 5),
                        (20, 15),
                        (15, 15),
                        (15, 5),
                        (5, 5),
                        (1, 15),
                        (1, 10),
                        (10, 5),
                        (5, 1)
                    };
                }

                void MovePlayer()
                {
                    switch (direction)
                    {
                        case Direction.UP:
                            if (playerY > 1 && maze[playerY - 1, playerX] != W) playerY--;
                            break;
                        case Direction.DOWN:
                            if (playerY < maxDown && maze[playerY + 1, playerX] != W) playerY++;
                            break;
                        case Direction.LEFT:
                            if (playerX > 1 && maze[playerY, playerX - 1] != W) playerX--;
                            break;
                        case Direction.RIGHT:
                            if (playerX < maxRight && maze[playerY, playerX + 1] != W) playerX++;
                            break;
                    }

                    if (maze[playerY, playerX] == o)
                    {
                        maze[playerY, playerX] = S;  
                        score++;  
                }

                void MoveEnemies()
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        int move = random.Next(4);
                        var (x, y) = enemies[i];
                        switch (move)
                        {
                            case 0: if (y > 1 && maze[y - 1, x] != W) y--; break; // Up
                            case 1: if (y < maxDown && maze[y + 1, x] != W) y++; break; // Down
                            case 2: if (x > 1 && maze[y, x - 1] != W) x--; break; // Left
                            case 3: if (x < maxRight && maze[y, x + 1] != W) x++; break; // Right
                        }
                        enemies[i] = (x, y);
                    }
                }

                void Draw()
                {
                    Console.Clear();
                    for (int i = 0; i < rowLength; i++)
                    {
                        for (int j = 0; j < colLength; j++)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write(maze[i, j]);
                        }
                    }

                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write(PLAYER);

                    foreach (var (x, y) in enemies)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(ENEMY);
                    }

                    Console.SetCursorPosition(0, maxDown + 2);
                    Console.WriteLine($"Score: {score}");
                }

                Console.CursorVisible = false;
                var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                var stepMs = 200;

                while (true)
                {
                    while (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;
                        direction = key switch
                        {
                            ConsoleKey.UpArrow => Direction.UP,
                            ConsoleKey.DownArrow => Direction.DOWN,
                            ConsoleKey.LeftArrow => Direction.LEFT,
                            ConsoleKey.RightArrow => Direction.RIGHT,
                            ConsoleKey.R => Direction.DOWN, 
                            _ => direction
                        };

                        if (key == ConsoleKey.R)
                        {
                            ResetLevel();
                        }
                    }

                    long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    if (now - startTime < stepMs) continue;
                    startTime = now;

                    MovePlayer();
                    MoveEnemies();
                    Draw();

                    foreach (var (x, y) in enemies)
                    {
                        if (playerX == x && playerY == y)
                        {
                            ResetLevel();
                            GameOver gameOver = new GameOver();
                            bool restart = gameOver.printOnGameOver();

                            if (!restart) 
                            {
                                return; 
                            }
                            else
                            {
                                ResetLevel(); 
                            }
                        }
                    }
                }
            }
        }

        enum Direction { UP, DOWN, LEFT, RIGHT }
    }
}

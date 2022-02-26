using System;
using static System.Console;

namespace pacman
{
    class PlayerMovement
    {
        World world = new World();
        public void movePlayer()
        {
            const string toWrite = "*";
            int x = 1, y = 1;
            Write(toWrite);

            while (true)
            {
                Console.CursorVisible = false;
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            y++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (y > 0)
                            {
                                y--;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (x > 0)
                            {
                                x--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            x++;
                            break;
                    }
                    world.DrawWorld();
                    Write(toWrite, x, y);
                }
            }
        }
        public void Write(string toWrite, int x = 1, int y = 1)
        {
            if (x >= 0 && y >= 0)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(toWrite);
            }
        }
    }
}
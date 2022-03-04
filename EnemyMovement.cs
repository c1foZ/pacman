using System;

namespace pacman
{
    class EnemyMovement
    {
        const string ENEMY = "X";
        public int enemyPositionX = 0, enemyPositionY = 0;
        int enemyCursorX = 14, enemyCursorY = 16;
        public void enemyMove()
        {
            if (enemyCursorX != 10 && enemyCursorY == 16)
            {
                enemyCursorX--;
                Console.SetCursorPosition(enemyCursorX, enemyCursorY);
                Console.Write(ENEMY);
                enemyPositionX = enemyCursorX;
                enemyPositionY = enemyCursorY;
            }

            if (enemyCursorX == 10 && enemyCursorY != 3)
            {
                enemyCursorY--;
                Console.SetCursorPosition(enemyCursorX, enemyCursorY + 1);
                Console.Write(ENEMY);
                enemyPositionX = enemyCursorX;
                enemyPositionY = enemyCursorY + 1;
            }

            if (enemyCursorX != 15 && enemyCursorY == 3)
            {
                enemyCursorX++;
                Console.SetCursorPosition(enemyCursorX - 1, enemyCursorY + 1);
                Console.Write(ENEMY);
                enemyPositionX = enemyCursorX - 1;
                enemyPositionY = enemyCursorY + 1;
            }

            if (enemyCursorX == 15 && enemyCursorY != 16)
            {
                enemyCursorY++;
                Console.SetCursorPosition(enemyCursorX - 1, enemyCursorY);
                Console.Write(ENEMY);
                enemyPositionX = enemyCursorX - 1;
                enemyPositionY = enemyCursorY;

            }
        }
    }
}
using static Pacman.EnemyCoords;
using static Pacman.Constants;

namespace Pacman
{
    class Enemy
    {
        private Renderer rd = new Renderer();

        public void EnemyMove()
        {
            if (CursorX != ENEMY_LEFT_TRAJECTORY && CursorY == ENEMY_BOTTOM_TRAJECTORY)
            {
                CursorX--;
                rd.PrintEnemy(CursorX, CursorY);
                SavePosition(CursorX, CursorY);
            }

            if (CursorX == ENEMY_LEFT_TRAJECTORY && CursorY != ENEMY_TOP_TRAJECTORY)
            {
                CursorY--;
                rd.PrintEnemy(CursorX, CursorY + 1);
                SavePosition(CursorX, CursorY + 1);
            }

            if (CursorX != ENEMY_RIGHT_TRAJECTORY && CursorY == ENEMY_TOP_TRAJECTORY)
            {
                CursorX++;
                rd.PrintEnemy(CursorX - 1, CursorY + 1);
                SavePosition(CursorX - 1, CursorY + 1);
            }

            if (CursorX == ENEMY_RIGHT_TRAJECTORY && CursorY != ENEMY_BOTTOM_TRAJECTORY)
            {
                CursorY++;
                rd.PrintEnemy(CursorX - 1, CursorY);
                SavePosition(CursorX - 1, CursorY);
            }
        }

        private void SavePosition(int cursorX, int cursorY)
        {
            X = cursorX;
            Y = cursorY;
        }
    }
}
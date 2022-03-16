namespace Pacman
{
    class Enemy
    {
        private Renderer rd = new Renderer();
        public int enemyPositionX = 0, enemyPositionY = 0;
        private int enemyCursorX = Constants.ENEMY_RIGHT_TRAJECTORY, enemyCursorY = Constants.ENEMY_BOTTOM_TRAJECTORY;

        public void EnemyMove()
        {
            if (enemyCursorX != Constants.ENEMY_LEFT_TRAJECTORY && enemyCursorY == Constants.ENEMY_BOTTOM_TRAJECTORY)
            {
                enemyCursorX--;
                rd.PrintEnemy(enemyCursorX, enemyCursorY);
                SavePosition(enemyCursorX, enemyCursorY);
            }

            if (enemyCursorX == Constants.ENEMY_LEFT_TRAJECTORY && enemyCursorY != Constants.ENEMY_TOP_TRAJECTORY)
            {
                enemyCursorY--;
                rd.PrintEnemy(enemyCursorX, enemyCursorY + 1);
                SavePosition(enemyCursorX, enemyCursorY + 1);
            }

            if (enemyCursorX != Constants.ENEMY_RIGHT_TRAJECTORY && enemyCursorY == Constants.ENEMY_TOP_TRAJECTORY)
            {
                enemyCursorX++;
                rd.PrintEnemy(enemyCursorX - 1, enemyCursorY + 1);
                SavePosition(enemyCursorX - 1, enemyCursorY + 1);
            }

            if (enemyCursorX == Constants.ENEMY_RIGHT_TRAJECTORY && enemyCursorY != Constants.ENEMY_BOTTOM_TRAJECTORY)
            {
                enemyCursorY++;
                rd.PrintEnemy(enemyCursorX - 1, enemyCursorY);
                SavePosition(enemyCursorX - 1, enemyCursorY);
            }
        }

        private void SavePosition(int cursorX, int cursorY)
        {
            enemyPositionX = cursorX;
            enemyPositionY = cursorY;
        }
    }
}
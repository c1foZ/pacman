namespace Pacman
{
    class PlayerMovement
    {
        private World world = new World();
        private Renderer rd = new Renderer();
        public int playerPositionX { get; private set; } = Constants.PLAYER_STARTING_POSITION_X;
        public int playerPositionY { get; private set; } = Constants.PLAYER_STARTING_POSITION_Y;

        public void MoveCursor()
        {
            if (playerPositionX >= 1 && playerPositionY >= 1)
            {
                rd.PrintPlayer(playerPositionX, playerPositionY);
            }
        }

        public void Right()
        {
            if (world.maze[playerPositionY, playerPositionX + 1] != Constants.W)
            {
                playerPositionX++;
            }
        }

        public void Left()
        {
            if (world.maze[playerPositionY, playerPositionX - 1] != Constants.W)
            {
                playerPositionX--;
            }
        }

        public void Up()
        {
            if (world.maze[playerPositionY - 1, playerPositionX] != Constants.W)
            {
                playerPositionY--;
            }
        }

        public void Down()
        {
            if (world.maze[playerPositionY + 1, playerPositionX] != Constants.W)
            {
                playerPositionY++;
            }
        }
    }
}

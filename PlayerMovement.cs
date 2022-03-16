using static Pacman.PlayerCoords;
namespace Pacman
{
    class PlayerMovement
    {
        private World world = new World(); //delete
        private Renderer rd = new Renderer(); //delete

        public void MoveCursor()
        {
            if (X >= 1 && Y >= 1)
            {
                rd.PrintPlayer(X, Y);
            }
        }

        public void Right()
        {
            if (world.maze[Y, X + 1] != Constants.W)
            {
                X++;
            }
        }

        public void Left()
        {
            if (world.maze[Y, X - 1] != Constants.W)
            {
                X--;
            }
        }

        public void Up()
        {
            if (world.maze[Y - 1, X] != Constants.W)
            {
                Y--;
            }
        }

        public void Down()
        {
            if (world.maze[Y + 1, X] != Constants.W)
            {
                Y++;
            }
        }
    }
}

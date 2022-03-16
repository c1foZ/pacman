using static Pacman.Constants;
namespace Pacman
{
    class World
    {
        private Renderer rd = new Renderer();
        public string[,] maze =  {
                {W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W},
                {W,S,O,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,O,W},
                {W,S,S,W,S,W,S,O,S,W,S,S,W,S,S,W,S,W,S,O,S,W,S,S,W},
                {W,O,S,W,O,S,S,W,S,O,S,S,W,O,S,W,O,S,S,W,S,O,S,S,W},
                {W,S,O,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,O,W},
                {W,S,S,W,S,W,S,O,S,W,S,S,W,S,S,W,S,W,S,O,S,W,S,S,W},
                {W,O,S,W,O,S,S,W,S,O,S,S,W,O,S,W,O,S,S,W,S,O,S,S,W},
                {W,S,O,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,O,W},
                {W,S,S,W,S,W,S,O,S,W,S,S,W,S,S,W,S,W,S,O,S,W,S,S,W},
                {W,O,S,W,O,S,S,W,S,O,S,S,W,O,S,W,O,S,S,W,S,O,S,S,W},
                {W,S,O,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,O,W},
                {W,S,S,W,S,W,S,O,S,W,S,S,W,S,S,W,S,W,S,O,S,W,S,S,W},
                {W,O,S,W,O,S,S,W,S,O,S,S,W,O,S,W,O,S,S,W,S,O,S,S,W},
                {W,S,O,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,O,W},
                {W,S,S,W,S,W,S,O,S,W,S,S,W,S,S,W,S,W,S,O,S,W,S,S,W},
                {W,O,S,W,O,S,S,W,S,O,S,S,W,O,S,W,O,S,S,W,S,O,S,S,W},
                {W,S,O,S,S,W,S,W,S,W,S,S,S,S,S,S,S,W,S,W,S,W,S,O,W},
                {W,S,S,W,S,W,S,O,S,W,S,S,W,S,S,W,S,W,S,O,S,W,S,S,W},
                {W,O,S,W,O,S,S,W,S,O,S,S,W,O,S,W,O,S,S,W,S,O,S,S,W},
                {W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W},
            };

        public void RenderWorld()
        {
            int rowLength = maze.GetLength(0);
            int colLength = maze.GetLength(1);

            for (int mazePositionX = 0; mazePositionX < rowLength; mazePositionX++)
            {
                for (int mazePositionY = 0; mazePositionY < colLength; mazePositionY++)
                {
                    string element = maze[mazePositionX, mazePositionY];
                    rd.PrintWorld(element, mazePositionY, mazePositionX);
                }
            }
        }
    }
}

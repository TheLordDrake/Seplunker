using RLNET;

namespace Spelunker
{
    class Program
    {
        private static RLRootConsole _rootConsole;

        public static void Main(string[] args)
        {
            // Path to Font img, width of window in tiles, height of window in tiles, width of tile in pixels, height of tile in pixels
            _rootConsole = new RLRootConsole("assets/terminal8x8.png", 60, 40, 8, 8);
            var engine = new Engine(_rootConsole);
            _rootConsole.Run();
        }
    }
}

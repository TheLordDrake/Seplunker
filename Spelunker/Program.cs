using RLNET;
using RogueSharp;
using RogueSharp.MapCreation;

namespace Spelunker
{
    class Program
    {
        private static RLRootConsole _rootConsole;
        private static IMap _map;


        public static void Main(string[] args)
        {
            IMapCreationStrategy<Map> mapCreationStrategy = new RandomRoomsMapCreationStrategy<Map>(50, 30, 100, 7, 3);
            _map = Map.Create(mapCreationStrategy);

            // Path to Font img, width of window in tiles, height of window in tiles, width of tile in pixels, height of tile in pixels
            _rootConsole = new RLRootConsole("assets/terminal8x8.png", 60, 40, 8, 8);
            var engine = new Engine(_rootConsole, _map);
            _rootConsole.Run();
        }
    }
}

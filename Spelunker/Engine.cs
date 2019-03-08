using RLNET;
using RogueSharp;
using Spelunker.entities;

namespace Spelunker
{
    internal class Engine
    {
        private readonly RLRootConsole _rootConsole;

        private IMap _map;

        private Player _player;

        public Engine(RLRootConsole console, IMap map)
        {
            _map = map;
            _player = new Player();

            _rootConsole = console;
            _rootConsole.Render += Render;
            _rootConsole.Update += Update;
        }

        private void Render(object sender, UpdateEventArgs e)
        {
            _rootConsole.Clear();

            foreach (var tile in _map.GetAllCells())
            {
                if (InRenderDistance(tile))
                {
                    _rootConsole.Set(tile.X, tile.Y, RLColor.LightGray, null, (tile.IsWalkable ? '.' : '#'));
                }
            }

            _rootConsole.Set(_player.X, _player.Y, _player.Color, null, Player.Icon);

            _rootConsole.Draw();
        }

        private void Update(object sender, UpdateEventArgs e)
        {
            RLKeyPress keyPress = _rootConsole.Keyboard.GetKeyPress();

            if (keyPress != null)
            {
                switch (keyPress.Key)
                {
                    case RLKey.Up:
                        if (_player.Y > 0 && _map.GetCell(_player.X, _player.Y - 1).IsWalkable)
                        {
                            _player.Y--;
                        }
                        break;
                    case RLKey.Down:
                        if (_player.Y < 50 && _map.GetCell(_player.X, _player.Y + 1).IsWalkable)
                        {
                            _player.Y++;
                        }
                        break;
                    case RLKey.Left:
                        if (_player.X > 0 && _map.GetCell(_player.X - 1, _player.Y).IsWalkable)
                        {
                            _player.X--;
                        }
                        break;
                    case RLKey.Right:
                        if (_player.X < 50 && _map.GetCell(_player.X + 1, _player.Y).IsWalkable)
                        {
                            _player.X++;
                        }
                        break;
                }
            }
        }

        private bool InRenderDistance(ICell tile)
        {
            int range = 10;
            if ((tile.X <= _player.X + range && tile.X >= _player.X - range) && (tile.Y <= _player.Y + range && tile.Y >= _player.Y - range))
            {
                return true;
            }

            return false;
        }
    }
}

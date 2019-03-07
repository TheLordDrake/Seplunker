using RLNET;
using RogueSharp;

namespace Spelunker
{
    internal class Engine
    {
        private readonly RLRootConsole _rootConsole;

        private IMap _map;

        private int _playerX;
        private int _playerY;

        public Engine(RLRootConsole console, IMap map)
        {
            _map = map;

            _rootConsole = console;
            _rootConsole.Render += Render;
            _rootConsole.Update += Update;
        }

        private void Render(object sender, UpdateEventArgs e)
        {
            _rootConsole.Clear();
            _rootConsole.Set(_playerX, _playerY, RLColor.White, null, '@');
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
                        _playerY--;
                        break;
                    case RLKey.Down:
                        _playerY++;
                        break;
                    case RLKey.Left:
                        _playerX--;
                        break;
                    case RLKey.Right:
                        _playerX++;
                        break;
                }
            }
        }
    }
}

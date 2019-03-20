using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spelunker.entities;

namespace Spelunker
{
    static class CharMap
    {
        public static readonly Dictionary<Entities, char> Map = new Dictionary<Entities, char>
        {
            {Entities.Player, '@'},
            {Entities.Floor, '.'},
            {Entities.Wall, '#'}
        };
    }
}

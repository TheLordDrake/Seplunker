﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Spelunker.entities
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        public const char Icon = '@';
        public RLColor Color = RLColor.LightGreen;

        public Player()
        {
            X = 25;
            Y = 25;
        }
    }
}

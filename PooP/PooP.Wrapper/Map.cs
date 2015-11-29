﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Wrapper
{
    public enum TileType
    {
        Plain = 0,
        Mountain = 1,
        Forest = 2,
        Water = 3
    }

    public class WMap
    {
        public WMap(TileType[] tiles)
        {
            Tiles = tiles;
        }
        public TileType[] Tiles { get; private set; }
    }
}

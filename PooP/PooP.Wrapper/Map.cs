using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Wrapper
{
    public class WMap
    {
        public WMap(TileType[] tiles)
        {
            Tiles = tiles;
        }
        public TileType[] Tiles { get; private set; }
    }
}

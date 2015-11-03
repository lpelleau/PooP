using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class TileFactory
    {
        public Dictionary<Tile, List<Position>> Tiles
        {
            get;
            set;
        }
    
        public Tile getTile(string TileType)
        {
            throw new System.NotImplementedException();
        }

        public Unit getBestDefender()
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Ressource
{
    public enum TileType
    {
        Plain = 0,
        Mountain = 1,
        Forest = 2,
        Water = 3
    }

    public enum WRace
    {
        Human = 0,
        Orc = 1,
        Elf = 2
    };

    public class WMap
    {
        public WMap(TileType[] tiles)
        {
            Tiles = tiles;
        }
        public TileType[] Tiles { get; private set; }
    }
}

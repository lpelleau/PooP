using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Wrapper;
using PooP.Core.Ressource;

namespace PooP.Core.Implementation.Maps
{
    /// <summary>
    /// Implements a demo map
    /// </summary>
    /// <see cref="CreateMap"/>
    public class DemoMap : CreateMap
    {
        /// <summary>
        /// A demo map is 6x6 tiles large
        /// </summary>
        private static int SIZE = 6;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public TileFactory create()
        {
            // TODO
            throw new NotImplementedException();
            //foreach (var tile in new Algo().CreateMap(SIZE * SIZE).Tiles)
            //{
            //Console.WriteLine(tile);
            //}
        }
    }

    /// <summary>
    /// Implements a small game map
    /// </summary>
    /// <see cref="CreateMap"/>
    public class SmallMap : CreateMap
    {
        /// <summary>
        /// A small map is 10x10 tiles large
        /// </summary>
        private static int SIZE = 10;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public TileFactory create()
        {
            TileFactory fact = new TileFactory();
            fact.Tiles = new Dictionary<Tile, List<Position>>();
            TileType[] map = new Algo().CreateMap(SIZE * SIZE).Tiles;

            for (int x = 0 ; x < SIZE ; x++)
            {
                for (int y = 0 ; y < SIZE ; y++)
                {
                    switch(map[x * SIZE + y]) {
                        case TileType.Forest:   fact.getTile("Forest", new Position(x, y));   break;
                        case TileType.Mountain: fact.getTile("Mountain", new Position(x, y)); break;
                        case TileType.Plain:    fact.getTile("Plain", new Position(x, y));    break;
                        case TileType.Water:    fact.getTile("Water", new Position(x, y));    break;
                    }
                }
            }

            return fact;
        }
    }

    /// <summary>
    /// Implements a standard map
    /// </summary>
    /// <see cref="CreateMap"/>
    public class StandardMap : CreateMap
    {
        /// <summary>
        /// A standard map is 14x14 tiles large
        /// </summary>
        private static int SIZE = 14;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public TileFactory create()
        {
            // TODO
            throw new NotImplementedException();
            //foreach (var tile in new Algo().CreateMap(SIZE * SIZE).Tiles)
            //{
                //Console.WriteLine(tile);
            //}
        }
    }
}

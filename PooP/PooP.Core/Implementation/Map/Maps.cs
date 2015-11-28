﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Wrapper;
using PooP.Core.Ressource;
using PooP.Core.Implementation.Games;

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
        public Map create()
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
        public Map create()
        {
            MapImpl fact = new MapImpl();
            fact.Tiles = new Dictionary<Tile, List<Position>>();
            int[] players = new int[4];
            TileType[] map = new Algo().CreateMap(SIZE * SIZE, players).Tiles;

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

            Position p1 = new Position(players[0], players[1]);
            for (int i = 0; i < 5; i++)
            {
                UnitImpl u = new UnitImpl(GameBuilder.CURRENTGAME.Players[0].Race, p1);
                GameBuilder.CURRENTGAME.Players[0].Race.Units.Add(u);
            }

            Position p2 = new Position(players[2], players[3]);
            for (int i = 0; i < 5; i++)
            {
                UnitImpl u = new UnitImpl(GameBuilder.CURRENTGAME.Players[1].Race, p2);
                GameBuilder.CURRENTGAME.Players[1].Race.Units.Add(u);
            }

            GameBuilder.CURRENTGAME.FirstPlayer = GameBuilder.CURRENTGAME.Players[new Random().Next() % 2];

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
        public Map create()
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

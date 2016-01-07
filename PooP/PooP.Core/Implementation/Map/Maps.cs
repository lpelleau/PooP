using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
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
        public static int SIZE = 6;

        /// <summary>
        /// A standard number of players is 8
        /// </summary>
        private static int NB_UNITS = 4;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public Map create()
        {
            MapImpl fact = new MapImpl();
            fact.Tiles = new Dictionary<Tile, List<Position>>();
            TileType[] map = Algo.INSTANCE.CreateMap(SIZE * SIZE).Tiles;

            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    switch (map[x * SIZE + y])
                    {
                        case TileType.Forest: fact.getTile("Forest", new Position(x, y)); break;
                        case TileType.Mountain: fact.getTile("Mountain", new Position(x, y)); break;
                        case TileType.Plain: fact.getTile("Plain", new Position(x, y)); break;
                        case TileType.Water: fact.getTile("Water", new Position(x, y)); break;
                    }
                }
            }

            int[] players = Algo.INSTANCE.PlacePlayers(SIZE * SIZE);

            for (int p = 0; p < players.Count(); p += 2)
            {
                GameBuilder.CURRENTGAME.Players[p / 2].Race.Units.Clear();
                Position pos = new Position(players[p], players[p + 1]);
                for (int i = 0; i < NB_UNITS; i++)
                {
                    UnitImpl u = new UnitImpl(GameBuilder.CURRENTGAME.Players[p / 2].Race, pos);
                    GameBuilder.CURRENTGAME.Players[p / 2].Race.Units.Add(u);
                }
            }

            GameBuilder.CURRENTGAME.FirstPlayer = GameBuilder.CURRENTGAME.Players[new Random().Next() % GameBuilder.CURRENTGAME.Players.Count()];

            return fact;
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
        /// A standard number of players is 8
        /// </summary>
        private static int NB_UNITS = 6;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public Map create()
        {
            MapImpl fact = new MapImpl();
            fact.Tiles = new Dictionary<Tile, List<Position>>();
            TileType[] map = Algo.INSTANCE.CreateMap(SIZE * SIZE).Tiles;

            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    switch (map[x * SIZE + y])
                    {
                        case TileType.Forest: fact.getTile("Forest", new Position(y, x)); break;
                        case TileType.Mountain: fact.getTile("Mountain", new Position(y, x)); break;
                        case TileType.Plain: fact.getTile("Plain", new Position(y, x)); break;
                        case TileType.Water: fact.getTile("Water", new Position(y, x)); break;
                    }
                }
            }

            int[] players = Algo.INSTANCE.PlacePlayers(SIZE * SIZE);

            for (int p = 0; p < players.Count(); p += 2)
            {
                GameBuilder.CURRENTGAME.Players[p / 2].Race.Units.Clear();
                Position pos = new Position(players[p], players[p + 1]);
                for (int i = 0; i < NB_UNITS; i++)
                {
                    UnitImpl u = new UnitImpl(GameBuilder.CURRENTGAME.Players[p/2].Race, pos);
                    GameBuilder.CURRENTGAME.Players[p / 2].Race.Units.Add(u);
                }
            }

            GameBuilder.CURRENTGAME.FirstPlayer = GameBuilder.CURRENTGAME.Players[new Random().Next() % GameBuilder.CURRENTGAME.Players.Count()];

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
        /// A standard number of players is 8
        /// </summary>
        private static int NB_UNITS = 8;

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <see cref="CreateMap"/>
        public Map create()
        {
            MapImpl fact = new MapImpl();
            fact.Tiles = new Dictionary<Tile, List<Position>>();
            TileType[] map = Algo.INSTANCE.CreateMap(SIZE * SIZE).Tiles;

            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    switch (map[x * SIZE + y])
                    {
                        case TileType.Forest: fact.getTile("Forest", new Position(x, y)); break;
                        case TileType.Mountain: fact.getTile("Mountain", new Position(x, y)); break;
                        case TileType.Plain: fact.getTile("Plain", new Position(x, y)); break;
                        case TileType.Water: fact.getTile("Water", new Position(x, y)); break;
                    }
                }
            }

            int[] players = Algo.INSTANCE.PlacePlayers(SIZE * SIZE);

            for (int p = 0; p < players.Count(); p += 2)
            {
                GameBuilder.CURRENTGAME.Players[p / 2].Race.Units.Clear();
                Position pos = new Position(players[p], players[p + 1]);
                for (int i = 0; i < NB_UNITS; i++)
                {
                    UnitImpl u = new UnitImpl(GameBuilder.CURRENTGAME.Players[p / 2].Race, pos);
                    GameBuilder.CURRENTGAME.Players[p / 2].Race.Units.Add(u);
                }
            }

            GameBuilder.CURRENTGAME.FirstPlayer = GameBuilder.CURRENTGAME.Players[new Random().Next() % GameBuilder.CURRENTGAME.Players.Count()];

            return fact;
        }
    }
}

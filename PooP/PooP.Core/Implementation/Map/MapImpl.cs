using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Core.Interfaces;
using PooP.Core.Ressource;
using PooP.Core.Data.Maps;
using PooP.Core.Exceptions;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces.Races;

namespace PooP.Core.Implementation.Maps
{
    /// <summary>
    /// Creates the needed tiles and affects them to their positions
    /// </summary>
    public class MapImpl : Map
    {
        // The created tiles, with their positions
        public Dictionary<Tile, List<Position>> Tiles
        {
            get;
            set;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MapImpl()
        {
        }
        
        /// <summary>
        /// Creates a tile factory from a data file
        /// </summary>
        /// <param name="data">Datas to load</param>
        public MapImpl(MapData data)
        {
            if (Tiles == null)
                Tiles =  new Dictionary<Tile, List<Position>>();
            else
                Tiles.Clear();
            data.Tiles.ForEach(c => Tiles.Add(ToTile(c.Name), c.Positions));
        }

        /// <summary>
        /// Computes and creates the tile type corresponding to a string name
        /// </summary>
        /// <param name="t">Tile type name</param>
        /// <returns>The created tile</returns>
        private Tile ToTile(string t)
        {
            Tile tile = null;
            switch(t.ToLower())
            {
                case "forest":
                    tile = new Forest();
                    break;
                case "mountain":
                    tile = new Mountain();
                    break;
                case "plain":
                    tile = new Plain();
                    break;
                case "water":
                    tile = new Water();
                    break;
                default:
                    throw new TileTypeException(t);
            }
            return tile;
        }

        // Creates a tile for the given type and position
        // If a tile of the given type already exists, it will only have another position more
        // If the position is already used, throw an exception
        public Tile getTile(string TileType, Position Position)
        {
            // If the position is already used, throw an exception
            if (Tiles.Where(l => l.Value.Contains(Position)).Count() != 0)
                throw new BadPositionException("Position already used");
            // If there is no tile of this type yet, create it
            if (Tiles.Count(e => e.Key.GetType().Name == TileType) == 0)
            {
                Tile t = ToTile(TileType);
                List<Position> l = new List<Position>();
                l.Add(Position);
                Tiles.Add(t, l);
                return t;
            }
            // If there is one, return it
            else
            {
                Tiles.First(e => e.Key.GetType().Name == TileType).Value.Add(Position);
                return Tiles.First(e => e.Key.GetType().Name == TileType).Key;
            }
        }

        /// <summary>
        /// Gives a list of units at a given position
        /// </summary>
        /// <param name="Position">Position to inspect</param>
        /// <returns>The units standing at this position</returns>
        private List<Unit> getUnits(Position Position)
        {
            List<Unit> units = new List<Unit>();
            for (int i = 0; i < GameBuilder.CURRENTGAME.Players.Length; i++)
            {
                GameBuilder.CURRENTGAME.Players[i].Race.Units.ForEach(u => 
                    {
                        if (u.Position.Equals(Position)) {
                            units.Add(u);
                        }
                    });
            }
            return units;
        }

        /// <summary>
        /// Gives the tile that is at a given position
        /// </summary>
        /// <param name="Position">Position to inspect</param>
        /// <returns>The tile type at this position</returns>
        public Tile getTileAt(Position Position)
        {
            return Tiles.FirstOrDefault(l => l.Value.Contains(Position)).Key;
        }

        /// <summary>
        /// Computes the unit that can defend the best the tile at a given position
        /// Since there can be only one Race at a time, the best defender is the one with the best HP
        /// </summary>
        /// <param name="Position">Position to inspect</param>
        /// <returns>The best defender for this position</returns>
        public Unit getBestDefenderAt(Position Position)
        {
            return getUnits(Position).Where(u => u.LifePoints == getUnits(Position).Max(un => un.LifePoints)).First();
        }

        /// <summary>
        /// Tells if there is a unit at a position
        /// </summary>
        /// <param name="dest">Position to test</param>
        /// <param name="r">Race that could occupy the position</param>
        /// <returns>true if there is at least one unit on this tile, false otherwise</returns>
        public bool IsOccupied(Position dest, Race r)
        {
            return getUnits(dest).Count(u => u.Race != r) != 0;
        }

        /// <summary>
        /// Transforms the tile factory into datas
        /// </summary>
        /// <returns>The data object corresponding to the factory</returns>
        public MapData ToData()
        {
            List<TileCouple> tmpTiles = new List<TileCouple>();
            Tiles.Keys.ToList().ForEach(e => tmpTiles.Add(new TileCouple()
            {
                Name = e.GetType().Name,
                Positions = Tiles.First(k => k.Key == e).Value
            }));
            tmpTiles.Sort((k1, k2) => k1.Name.CompareTo(k2.Name));
            return new MapData
            {
                Tiles = tmpTiles
            };
        }
    }
}

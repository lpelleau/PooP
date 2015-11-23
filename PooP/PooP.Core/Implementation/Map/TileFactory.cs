using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Core.Interfaces;
using PooP.Core.Ressource;
using PooP.Core.Data.Maps;

namespace PooP.Core.Implementation.Maps
{
    public abstract class TileFactory
    {
        public static TileFactory TILE_GENERATOR;

        public TileFactory(TileFactoryData data)
        {
            data.Tiles.Keys.ToList().ForEach(e => Tiles.Add(ToTile(e), data.Tiles.First(k => k.Key == e).Value));
        }

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
            }
            return tile;
        }

        public Dictionary<Tile, List<Position>> Tiles
        {
            get;
            set;
        }

        // Creates a tile for the given type and position
        // If a tile of the given type already exists, it will only have another position more
        public Tile getTile(string TileType, Position Position)
        {
            // If there is no tile of this type yet, create it
            if (Tiles.Count(e => e.Key.GetType().Name == TileType) == 0)
            {
                Tile t;
                switch (TileType)
                {
                    case "Water":       t = new Water();    break;
                    case "Plain":       t = new Plain();    break;
                    case "Mountain":    t = new Mountain(); break;
                    case "Forest":      t = new Forest();   break;
                    default: throw new Exception();
                }
                Tiles.Add(t, new List<Position>());
                return t;
            }
            // If there is one, return it
            else
            {
                return Tiles.First(e => e.Key.GetType().Name == TileType).Key;
            }
        }

        // Gives a list of units at a given position
        // TODO Add the code
        private List<Unit> getUnits(Position Position)
        {
            return new List<Unit>();
        }

        // Gives the tile that is at a given position
        public Tile getTileAt(Position Position)
        {
            return Tiles.FirstOrDefault(l => l.Value.Contains(Position)).Key;
        }

        // Computes the unit that can defend the best the tile at a given position
        // Since there can be only one Race at a time, the best defender is th eone with the best HP
        public Unit getBestDefenderAt(Position Position)
        {
            return getUnits(Position).Where(u => u.LifePoints == getUnits(Position).Max(un => un.Race.Defence)).First();
        }

        // Tells if there is a unit at a position
        public bool IsOccupied(Position dest)
        {
            return getUnits(dest).Count == 0;
        }

        public TileFactoryData ToData()
        {
            Dictionary<string, List<Position>> tmpTiles = new Dictionary<string, List<Position>>();
            Tiles.Keys.ToList().ForEach(e => tmpTiles.Add(e.GetType().Name, Tiles.First(k => k.Key == e).Value));
            return new TileFactoryData
            {
                Tiles = tmpTiles
            };
        }
    }
}

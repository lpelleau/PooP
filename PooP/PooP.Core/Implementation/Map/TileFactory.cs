using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public abstract class TileFactory
    {
        public static TileFactory TILE_GENERATOR;

        public Dictionary<Tile, List<Position>> Tiles
        {
            get;
            set;
        }

        // Creates a tile for the given type and position
        // If a tile of the given type already exists, it will only have another position more
        public Tile getTile(string TileType, Position Position)
        {
            throw new System.NotImplementedException();
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
    }
}

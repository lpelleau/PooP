using PooP.Core.Data.Maps;
using PooP.Core.Interfaces.Races;
using PooP.Core.Ressource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Interfaces.Maps
{
    /// <summary>
    /// Represents a map
    /// </summary>
    public interface Map
    {
        int Height { get; set; }
        int Width { get; set; }

        // The created tiles, with their positions
        Dictionary<Tile, List<Position>> Tiles
        {
            get;
            set;
        }

        // Creates a tile for the given type and position
        // If a tile of the given type already exists, it will only have another position more
        // If the position is already used, throw an exception
        Tile getTile(string TileType, Position Position);

        /// <summary>
        /// Gives the tile that is at a given position
        /// </summary>
        /// <param name="Position">Position to inspect</param>
        /// <returns>The tile type at this position</returns>
        Tile getTileAt(Position Position);

        /// <summary>
        /// Computes the unit that can defend the best the tile at a given position
        /// Since there can be only one Race at a time, the best defender is the one with the best HP
        /// </summary>
        /// <param name="Position">Position to inspect</param>
        /// <returns>The best defender for this position</returns>
        Unit getBestDefenderAt(Position Position);

        /// <summary>
        /// Tells if there is a unit at a position
        /// </summary>
        /// <param name="dest">Position to test</param>
        /// <param name="r">Race that wish to occupy it</param>
        /// <returns>true if there is at least one unit on this tile, false otherwise</returns>
        bool IsOccupied(Position dest, Race r);

        /// <summary>
        /// Transforms the tile factory into datas
        /// </summary>
        /// <returns>The data object corresponding to the factory</returns>
        MapData ToData();
    }
}

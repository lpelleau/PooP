using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;

namespace PooP.Core.Interfaces.Maps
{
    /// <summary>
    /// Represents a tile
    /// </summary>
    public interface Tile
    {
        /// <summary>
        /// Tests if a tile is available for a given race
        /// </summary>
        /// <param name="Race">The race that wants to reach the tile</param>
        /// <returns>true if this race can move on this type of tile</returns>
        bool available(Race Race);
    }
}

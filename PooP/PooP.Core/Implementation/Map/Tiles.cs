using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Core.Interfaces.Races;

namespace PooP.Core.Implementation.Maps
{
    /// <summary>
    /// Implements a plain tile
    /// </summary>
    public class Plain : Tile
    {
        /// <summary>
        /// Tests if this tile is available for a given race
        /// </summary>
        /// <param name="Race">Race that wants to reach this tile</param>
        /// <returns>true if the race can move to a plain tile, false otherwise</returns>
        public bool available(Race Race)
        {
            return false;
        }
    }

    /// <summary>
    /// Implements a forest tile
    /// </summary>
    public class Forest : Tile
    {
        /// <summary>
        /// Tests if this tile is available for a given race
        /// </summary>
        /// <param name="Race">Race that wants to reach this tile</param>
        /// <returns>true if the race can move to a forest tile, false otherwise</returns>
        public bool available(Race Race)
        {
            return false;
        }
    }

    /// <summary>
    /// Implements a mountain tile
    /// </summary>
    public class Mountain : Tile
    {
        /// <summary>
        /// Tests if this tile is available for a given race
        /// </summary>
        /// <param name="Race">Race that wants to reach this tile</param>
        /// <returns>true if the race can move to a mountain tile, false otherwise</returns>
        public bool available(Race Race)
        {
            return false;
        }
    }

    /// <summary>
    /// Implements a water tile
    /// </summary>
    public class Water : Tile
    {
        /// <summary>
        /// Tests if this tile is available for a given race
        /// </summary>
        /// <param name="Race">Race that wants to reach this tile</param>
        /// <returns>true if the race can move to a water tile, false otherwise</returns>
        public bool available(Race Race)
        {
            return false;
        }
    }
}

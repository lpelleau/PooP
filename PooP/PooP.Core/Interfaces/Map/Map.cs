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
        /// <summary>
        /// The creator that created the map
        /// </summary>
        CreateMap MapCreator
        {
            get;
            set;
        }

        /// <summary>
        /// Tile factory associated to the game
        /// </summary>
        Implementation.Maps.TileFactory Tiles { get; set; }

        /// <summary>
        /// Creates a new map
        /// </summary>
        void createMap();
    }
}

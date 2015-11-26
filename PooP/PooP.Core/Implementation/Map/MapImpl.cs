using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;

namespace PooP.Core.Implementation.Maps
{
    /// <summary>
    /// Implements a map
    /// </summary>
    public class MapImpl : Map
    {
        /// <summary>
        /// The creator that created the map
        /// </summary>
        public CreateMap MapCreator
        {
            get;
            set;
        }

        /// <summary>
        /// Tile factory associated to the map
        /// </summary>
        public TileFactory Tiles
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new map
        /// </summary>
        public void createMap()
        {
            throw new System.NotImplementedException();
        }
    }
}

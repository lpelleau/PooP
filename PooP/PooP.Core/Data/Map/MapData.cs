using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Ressource;

namespace PooP.Core.Data.Maps
{
    /// <summary>
    /// Represents a map for the datas
    /// </summary>
    [Serializable]
    public class MapData
    {
        /// <summary>
        /// The list of tiles and positions
        /// </summary>
        public List<TileCouple> Tiles
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents a tile/position association
    /// </summary>
    [Serializable]
    public class TileCouple
    {
        /// <summary>
        /// Name of the tile type
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Position of the type
        /// </summary>
        public List<Position> Positions
        {
            get;
            set;
        }
    }
}

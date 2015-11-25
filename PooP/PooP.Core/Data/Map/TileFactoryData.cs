using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Ressource;

namespace PooP.Core.Data.Maps
{
    [Serializable]
    public class TileFactoryData
    {
        public List<TileCuple> Tiles
        {
            get;
            set;
        }
    }

    [Serializable]
    public class TileCuple
    {
        public string Name
        {
            get;
            set;
        }
        public List<Position> Positions
        {
            get;
            set;
        }
    }
}

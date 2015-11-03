using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class MapImpl : Map
    {
        public TileFactory TilesFactory
        {
            get;
            set;
        }

        public CreateMap MapCreator
        {
            get;
            set;
        }

        public void createMap()
        {
            throw new System.NotImplementedException();
        }
    }
}

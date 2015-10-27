using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class Map
    {
        public TileFactory TilesFactory
        {
            get
            {
                return TilesFactory;
            }
            set
            {
                TilesFactory = value;
            }
        }

        public PooP.Core.CreateMap MapCreator
        {
            get
            {
                return MapCreator;
            }
            set
            {
                MapCreator = value;
            }
        }

        public void createMap()
        {
            throw new System.NotImplementedException();
        }
    }
}

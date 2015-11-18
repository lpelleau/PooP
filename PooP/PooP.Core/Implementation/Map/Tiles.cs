using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Maps;
using PooP.Core.Interfaces.Races;

namespace PooP.Core.Implementation.Maps
{
    public class Plain : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
    }

    public class Forest : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
    }

    public class Mountain : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
    }

    public class Water : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
    }
}

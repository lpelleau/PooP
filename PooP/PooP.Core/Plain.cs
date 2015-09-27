using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class Plain : Tile
    {
        public override bool available(Race race)
        {
            return false;
        }
    }

    public class Forest : Tile
    {
        public override bool available(Race race)
        {
            return false;
        }
    }

    public class Mountain : Tile
    {
        public override bool available(Race race)
        {
            return false;
        }
    }

    public class Water : Tile
    {
        public override bool available(Race race)
        {
            return false;
        }
    }
}

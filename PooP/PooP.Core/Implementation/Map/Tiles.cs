using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class Plain : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
        public Unit getBestDefender()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Forest : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
        public Unit getBestDefender()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Mountain : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
        public Unit getBestDefender()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Water : Tile
    {

        public bool available(Race Race)
        {
            return false;
        }
        public Unit getBestDefender()
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public abstract class Tile
    {
        public int XPosition
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int YPosition
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Unit> Units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public abstract bool available(Race race);

        public Unit getBestDefender()
        {
            throw new System.NotImplementedException();
        }
    }
}

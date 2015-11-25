using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Ressource;
using PooP.Core.Interfaces;
using PooP.Core.Implementation;
using PooP.Core.Data.Races;

namespace PooP.Core.Data
{
    [Serializable]
    public class UnitData
    {
        public int LifePoints
        {
            get;
            set;
        }

        public Position Position
        {
            get;
            set;
        }

        public double MovePoints
        {
            get;
            set;
        }

        public Unit ToUnit()
        {
            return new UnitImpl(this);
        }
    }
}

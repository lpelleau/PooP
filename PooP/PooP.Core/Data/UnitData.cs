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
    /// <summary>
    /// Represents a unit for a save file
    /// </summary>
    [Serializable]
    public class UnitData
    {
        /// <summary>
        /// Life points of the unit
        /// </summary>
        public int LifePoints
        {
            get;
            set;
        }

        /// <summary>
        /// Position of the unit
        /// </summary>
        public Position Position
        {
            get;
            set;
        }

        /// <summary>
        /// Move points of the unit
        /// </summary>
        public double MovePoints
        {
            get;
            set;
        }

        /// <summary>
        /// Converts the data back to a concrete unit
        /// </summary>
        /// <returns>The real unit</returns>
        public Unit ToUnit()
        {
            return new UnitImpl(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PooP.Core.Interfaces.Races;
using PooP.Core.Implementation.Races;

namespace PooP.Core.Data.Races
{
    /// <summary>
    /// Represents a savable data race
    /// </summary>
    public class RaceData
    {
        /// <summary>
        /// The race standing units
        /// </summary>
        public List<UnitData> Units
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the race
        /// </summary>
        public string RaceName
        {
            get;
            set;
        }

        /// <summary>
        /// Converts the data race back into a real race
        /// </summary>
        /// <returns>The race that has been converted</returns>
        public Race ToRace()
        {
            Race r = RaceFactoryImpl.getRace(RaceName);
            r.Units = Units.ConvertAll(u => u.ToUnit());
            return r;
        }
    }
}

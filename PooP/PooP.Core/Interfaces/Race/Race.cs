using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Data.Races;

namespace PooP.Core.Interfaces.Races
{
    /// <summary>
    /// Represents a race
    /// </summary>
    public interface Race
    {
        /// <summary>
        /// Maximal life for the race unit
        /// </summary>
        int Life
        {
            get;
            set;
        }

        /// <summary>
        /// The attack for the race
        /// </summary>
        int Attack
        {
            get;
            set;
        }

        /// <summary>
        /// The defence for the race
        /// </summary>
        int Defence
        {
            get;
            set;
        }

        /// <summary>
        /// The attack distance for the race
        /// </summary>
        int AttackDistance
        {
            get;
            set;
        }

        /// <summary>
        /// The player that has choosen the race
        /// </summary>
        Player Player
        {
            get;
            set;
        }

        /// <summary>
        /// The standing units of the race
        /// </summary>
        List<Unit> Units
        {
            get;
            set;
        }

        /// <summary>
        /// The move distance for the race
        /// </summary>
        int MoveDistance
        {
            get;
            set;
        }

        /// <summary>
        /// Compute sthe victory points given by the race
        /// </summary>
        /// <returns>The victory points earned thanks to this race</returns>
        int getVictoryPoints();

        /// <summary>
        /// Tests if there are still units
        /// </summary>
        /// <returns>true if there is at least one unit, false otherwise</returns>
        bool hasUnits();

        /// <summary>
        /// Transforms a race into datas
        /// </summary>
        /// <returns>The data object representing the race</returns>
        RaceData ToData();
    }
}

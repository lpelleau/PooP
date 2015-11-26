using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Data.Races;
using PooP.Core.Interfaces;
using PooP.Core.Implementation;

namespace PooP.Core.Data
{
    /// <summary>
    /// Represents a player for a save file
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        /// <summary>
        /// Race choosen by the player
        /// </summary>
        public RaceData Race
        {
            get;
            set;
        }

        /// <summary>
        /// Player's name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Is the player the first to play ?
        /// </summary>
        public bool Fst
        {
            get;
            set;
        }

        /// <summary>
        /// Converts the data back to a concrete player
        /// </summary>
        /// <returns>The concrete player</returns>
        public Player ToPlayer()
        {
            return new PlayerImpl(this);
        }
    }
}

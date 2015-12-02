using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;
using PooP.Core.Data;

namespace PooP.Core.Interfaces
{
    /// <summary>
    /// Represents a player
    /// </summary>
    public interface Player
    {
        /// <summary>
        /// The race the player has choosen
        /// </summary>
        Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// Player's name
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Transforms the player into data, knowing whether or not it is the first player
        /// </summary>
        /// <param name="FstP">Is this player the first one ?</param>
        /// <returns>The data object representing the player</returns>
        PlayerData ToData(bool FstP);
    }
}

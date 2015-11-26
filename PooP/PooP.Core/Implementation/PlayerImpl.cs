using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Races;
using PooP.Core.Data;
using PooP.Core.Implementation.Races;

namespace PooP.Core.Implementation
{
    /// <summary>
    /// Implements a player
    /// </summary>
    public class PlayerImpl : Player
    {
        /// <summary>
        /// Loads a player from a data file
        /// </summary>
        /// <param name="data">Datas to load</param>
        public PlayerImpl(PlayerData data)
        {
            Race = data.Race.ToRace();
            Name = data.Name;
        }

        /// <summary>
        /// Creates a player with given name and race
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="race">Player's race</param>
        public PlayerImpl(string name, string race)
        {
            this.Name = name;
            this.Race = RaceFactoryImpl.getRace(race);
            this.Race.Player = this;
        }

        /// <summary>
        /// The player's race
        /// </summary>
        public Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Transforms a player into datas
        /// This one shall be used only if the player is not the first player
        /// </summary>
        /// <returns>The data object representing the player</returns>
        public PlayerData ToData()
        {
            return ToData(false);
        }

        /// <summary>
        /// Transforms the first (or not) player into datas
        /// </summary>
        /// <param name="FstP">true if the player is the first player, false otherwise</param>
        /// <returns>The data object representing this player</returns>
        public PlayerData ToData(bool FstP)
        {
            return new PlayerData
            {
                Race = this.Race.ToData(),
                Name = this.Name,
                Fst = FstP
            };
        }
    }
}

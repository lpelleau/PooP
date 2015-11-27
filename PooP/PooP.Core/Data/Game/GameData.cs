using PooP.Core.Data.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Data.Games
{
    /// <summary>
    /// Represents the game for a save file
    /// </summary>
    [Serializable]
    public class GameData
    {
        /// <summary>
        /// The first player to play
        /// </summary>
        public PlayerData FirstPlayer
        {
            get;
            set;
        }

        /// <summary>
        /// The players
        /// </summary>
        public List<PlayerData> Players
        {
            get;
            set;
        }

        /// <summary>
        /// The number of turns of the game
        /// </summary>
        public int NumberOfTurns
        {
            get;
            set;
        }

        /// <summary>
        /// The map of the game
        /// </summary>
        public MapData Tiles
        {
            get; set;
        }
    }
}

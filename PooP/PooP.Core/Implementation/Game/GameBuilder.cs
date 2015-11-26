using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Games;
using PooP.Core.Interfaces.Maps;

namespace PooP.Core.Implementation.Games
{
    /// <summary>
    /// Builds and launches a game
    /// </summary>
    public abstract class GameBuilder
    {
        /// <summary>
        /// Singleton
        /// Gives the current played game
        /// Allows to create only one game at a time
        /// </summary>
        public static GameImpl CURRENTGAME;

        /// <summary>
        /// A game with a given difficulty has a specific number of turns
        /// </summary>
        public abstract int NbTurns
        {
            get;
        }

        /// <summary>
        /// The name of the file in which the game is saved
        /// By default, it is null
        /// </summary>
        public string OpenedFile
        {
            get;
            set;
        }

        /// <summary>
        /// The Map of the game
        /// </summary>
        public Map Map
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a game
        /// </summary>
        /// <param name="players">An array with the players names as strings</param>
        /// <param name="races">An array with the players races as strings</param>
        public void createGame(string[] playersNames, string[] races)
        {
            Player[] p = getPlayers(playersNames, races);
            Map m = createMap();
            placeUnits();
            CURRENTGAME = new GameImpl(p,m,NbTurns);
            OpenedFile = null;
        }

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <returns>The created map</returns>
        public abstract Map createMap();

        /// <summary>
        /// Creates and places units on the map
        /// </summary>
        public abstract void placeUnits();

        /// <summary>
        /// Creates the players
        /// </summary>
        /// <param name="players">An array with the players names as strings</param>
        /// <param name="races">An array with the players races as strings</param>
        /// <returns>An array with </returns>
        public abstract Player[] getPlayers(string[] playersNames, string[] races);

        /// <summary>
        /// Starts the game
        /// </summary>
        public void start()
        {
            throw new System.NotImplementedException();
        }
    }
}

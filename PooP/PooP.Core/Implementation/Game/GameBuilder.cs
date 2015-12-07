using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Games;
using PooP.Core.Interfaces.Maps;
using PooP.Core.Interfaces.Races;
using PooP.Core.Exceptions;
using PooP.Core.Data.Games;
using PooP.Core.Implementation.Commands;
using PooP.Core.Interfaces.Commands;

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
        /// Loads a GameData game
        /// </summary>
        /// <param name="gd">Game to load</param>
        public static void createGame(GameData gd)
        {
            CURRENTGAME = new GameImpl(gd);
        }

        /// <summary>
        /// Creates a game
        /// </summary>
        /// <param name="players">An array with the players names as strings</param>
        /// <param name="races">An array with the players races as strings</param>
        public void createGame(string[] playersNames, string[] races)
        {
            List<string> UsedRaces = new List<string>();
            foreach (string race in races)
            {
                if (UsedRaces.Contains(race)) throw new RaceException(race);
                UsedRaces.Add(race);
            }
            Player[] p = getPlayers(playersNames, races);
            CURRENTGAME = new GameImpl(p, NbTurns);
            Map m = createMap();
            CURRENTGAME.Map = m;
            CURRENTGAME.FirstPlayer.Race.Units.ForEach(u => u.MovePoints = 2);
            OpenedFile = null;
            UndoableImpl.DoneCommands = new Stack<Command>();
            UndoableImpl.UndoneCommands = new Stack<Command>();
            EndTurn.winner = null;
        }

        /// <summary>
        /// Creates the map
        /// </summary>
        /// <returns>The created map</returns>
        public abstract Map createMap();

        /// <summary>
        /// Creates the players
        /// </summary>
        /// <param name="players">An array with the players names as strings</param>
        /// <param name="races">An array with the players races as strings</param>
        /// <returns>An array with </returns>
        public abstract Player[] getPlayers(string[] playersNames, string[] races);
    }
}

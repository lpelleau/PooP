using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Maps;
using PooP.Core.Interfaces.Games;
using PooP.Core.Implementation.Races;
using PooP.Core.Data.Games;
using PooP.Core.Implementation.Maps;
using PooP.Core.Exceptions;

namespace PooP.Core.Implementation.Games
{
    /// <summary>
    /// Implements a Game
    /// </summary>
    [Serializable]
    public class GameImpl : Game
    {

        /// <summary>
        /// Constructor from datas read in a file
        /// </summary>
        /// <param name="data">Datas to load</param>
        public GameImpl(GameData data)
        {
            FirstPlayer = new PlayerImpl(data.FirstPlayer);
            Players = data.Players.ConvertAll(p => p.ToPlayer()).ToArray();
            NumberOfTurns = data.NumberOfTurns;
            // TO DO : Load the tiles
        }

        /// <summary>
        /// Creates a game
        /// </summary>
        /// <param name="players">Names of the players</param>
        /// <param name="m">Map to use</param>
        /// <param name="turns">Number of turns for the game</param>
        public GameImpl(Player[] players, Map m, int turns)
        {
            Players = players;
            FirstPlayer = Players[new Random().Next(0,1)];
            NumberOfTurns = turns;
            // Load tiles from Map
        }

        /// <summary>
        /// First player to play
        /// </summary>
        public Player FirstPlayer
        {
            get;
            set;
        }

        /// <summary>
        /// Players of the game
        /// </summary>
        public Player[] Players
        {
            get;
            set;
        }

        /// <summary>
        /// Game map
        /// </summary>
        public Map Map
        {
            get;
            set;
        }

        /// <summary>
        /// Number of turns to play
        /// </summary>
        public int NumberOfTurns
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the player that is playing
        /// </summary>
        /// <returns></returns>
        public Player getCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the winner if there is one
        /// If the players are ex aequo, the first player wins
        /// </summary>
        /// <returns>The winning player</returns>
        public Player getWinner()
        {
            Player best = null;
            foreach (Player p in Players)
            {
                if (best == null || 
                    (RaceFactoryImpl.getRace(p.Race.GetType().Name).getVictoryPoints() >
                    RaceFactoryImpl.getRace(best.Race.GetType().Name).getVictoryPoints()))
                {
                    best = p;
                }
            }
            return best;
        }

        /// <summary>
        /// Ends the game
        /// </summary>
        public void endGame()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Transforms a game into data
        /// </summary>
        /// <returns>The data game object</returns>
        public GameData ToData()
        {
            return new GameData
            {
                FirstPlayer = this.FirstPlayer.ToData(),
                Players = this.Players.ToList().ConvertAll(p => (p.Equals(FirstPlayer)) ? p.ToData() : p.ToData(true)),
                NumberOfTurns = this.NumberOfTurns,
                Tiles = this.Map.Tiles.ToData()
            };
        }
    }
}

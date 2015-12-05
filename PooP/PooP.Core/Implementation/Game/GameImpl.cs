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
using PooP.Core.Data;
using PooP.Core.Implementation.Commands;
using PooP.Core.Interfaces.Commands;

namespace PooP.Core.Implementation.Games
{
    /// <summary>
    /// Implements a Game
    /// </summary>
    public class GameImpl : Game
    {

        /// <summary>
        /// Constructor from datas read in a file
        /// </summary>
        /// <param name="data">Datas to load</param>
        public GameImpl(GameData data)
        {
            List<Player> PlayersList = new List<Player>();
            foreach (PlayerData p in data.Players) {
                Player PlayerToAdd = p.ToPlayer();
                if (p.Fst)
                    FirstPlayer = PlayerToAdd;
                PlayersList.Add(PlayerToAdd);
            }
            Players = PlayersList.ToArray();
            NumberOfTurns = data.NumberOfTurns;
            Map = new MapImpl(data.Tiles);
            FirstPlayer.Race.Units.ForEach(u => u.MovePoints = 2);
            UndoableImpl.DoneCommands = new Stack<Command>();
            UndoableImpl.UndoneCommands = new Stack<Command>();
            EndTurn.winner = null;
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
            IndexOfCurrentPlayer = new Random().Next(0, players.Count() - 1);
            FirstPlayer = Players[IndexOfCurrentPlayer];
            NumberOfTurns = turns;
            Map = m;
        }

        /// <summary>
        /// Creates a game without the map
        /// </summary>
        /// <param name="players">Names of the players</param>
        /// <param name="turns">Number of turns for the game</param>
        public GameImpl(Player[] players, int turns)
        {
            Players = players;
            IndexOfCurrentPlayer = new Random().Next(0, players.Count() - 1);
            FirstPlayer = Players[IndexOfCurrentPlayer];
            NumberOfTurns = turns;
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

        private int indexOfCurrentPlayer;
        public int IndexOfCurrentPlayer
        {
            get {return indexOfCurrentPlayer; }
            set
            {
                indexOfCurrentPlayer = value % Players.Count();
                FirstPlayer = Players[indexOfCurrentPlayer];
            }
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
            return GameBuilder.CURRENTGAME.FirstPlayer;
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
            // TODO
        }

        /// <summary>
        /// Transforms a game into data
        /// </summary>
        /// <returns>The data game object</returns>
        public GameData ToData()
        {
            return new GameData
            {
                Players = this.Players.ToList().ConvertAll(p => p.ToData(p.Equals(this.FirstPlayer))),
                NumberOfTurns = this.NumberOfTurns,
                Tiles = this.Map.ToData()
            };
        }
    }
}

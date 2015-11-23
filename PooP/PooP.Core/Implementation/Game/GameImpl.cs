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

namespace PooP.Core.Implementation.Games
{
    [Serializable]
    public class GameImpl : Game
    {
        public static GameImpl CURRENTGAME = new GameImpl();
        public GameImpl(GameData data)
        {
            FirstPlayer = new PlayerImpl(data.FirstPlayer);
            Players = data.Players.ConvertAll(p => p.ToPlayer()).ToArray();
            NumberOfTurns = data.NumberOfTurns;
        }

        private GameImpl()
        {
        }

        public Player FirstPlayer
        {
            get;
            set;
        }

        public Player[] Players
        {
            get;
            set;
        }

        public Map Map
        {
            get;
            set;
        }

        public int NumberOfTurns
        {
            get;
            set;
        }

        public TileFactory Tiles
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Player getCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }

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

        public void endGame()
        {
            throw new System.NotImplementedException();
        }

        public GameData ToData()
        {
            return new GameData
            {
                FirstPlayer = this.FirstPlayer.ToData(),
                Players = this.Players.ToList().ConvertAll(p => p.ToData()),
                NumberOfTurns = this.NumberOfTurns,
                Tiles = this.Tiles.ToData()
            };
        }
    }
}

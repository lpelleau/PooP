using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    [Serializable]
    public class GameImpl : Game
    {
        private Player FirstPlayer;

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

        public int NumbreOfTurns
        {
            get;
            set;
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
                    (RaceFactory.getRace(p.Race.GetType().Name).getVictoryPoints() >
                    RaceFactory.getRace(best.Race.GetType().Name).getVictoryPoints()))
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
                NumbreOfTurns = this.NumbreOfTurns
            };
        }
    }
}

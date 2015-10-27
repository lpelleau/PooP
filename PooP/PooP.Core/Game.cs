using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class Game
    {
        private Player FirstPlayer;
    
        public PooP.Core.Player[] Players
        {
            get
            {
                return Players;
            }
            set
            {
                Players = value;
            }
        }

        public Map Map
        {
            get
            {
                return Map;
            }
            set
            {
                Map = value;
            }
        }

        public int NumbreOfTurns
        {
            get
            {
                return NumbreOfTurns;
            }
            set
            {
                NumbreOfTurns = value;
            }
        }

        public Player getCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }

        public Player getWinner()
        {
            throw new System.NotImplementedException();
        }

        public void close()
        {
            throw new System.NotImplementedException();
        }
    }
}

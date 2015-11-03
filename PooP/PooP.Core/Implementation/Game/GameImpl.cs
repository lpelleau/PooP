using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class GameImml : Game
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
            throw new System.NotImplementedException();
        }

        public void endGame()
        {
            throw new System.NotImplementedException();
        }
    }
}

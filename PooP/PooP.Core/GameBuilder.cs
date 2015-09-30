using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public abstract class GameBuilder
    {
        public System.IO.File OpenedFile
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public Game createGame()
        {
            throw new System.NotImplementedException();
        }

        public abstract Map createMap();

        public abstract void placeUnits();

        public abstract Player[] getPlayers();

        public void start()
        {
            throw new System.NotImplementedException();
        }
    }
}

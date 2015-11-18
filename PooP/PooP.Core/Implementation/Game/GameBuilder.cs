using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Games;
using PooP.Core.Interfaces.Maps;

namespace PooP.Core.Implementation.Games
{
    public abstract class GameBuilder
    {
        public string OpenedFile
        {
            get;
            set;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Data.Games
{
    public class GameData
    {
        public PlayerData FirstPlayer
        {
            get;
            set;
        }

        public List<PlayerData> Players
        {
            get;
            set;
        }

        public int NumberOfTurns
        {
            get;
            set;
        }
    }
}

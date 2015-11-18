using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
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

        public int NumbreOfTurns
        {
            get;
            set;
        }
    }
}

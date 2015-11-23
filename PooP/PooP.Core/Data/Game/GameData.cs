using PooP.Core.Data.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Data.Games
{
    [Serializable]
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

        public TileFactoryData Tiles
        {
            get; set;
        }
    }
}

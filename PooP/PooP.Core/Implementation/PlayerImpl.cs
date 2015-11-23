using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Races;
using PooP.Core.Data;

namespace PooP.Core.Implementation
{
    public class PlayerImpl : Player
    {
        public PlayerImpl(PlayerData data)
        {
            Race = data.Race.ToRace();
            Name = data.Name;
        }
        public Race Race
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public PlayerData ToData()
        {
            return new PlayerData
            {
                Race = this.Race.ToData(),
                Name = this.Name
            };
        }
    }
}

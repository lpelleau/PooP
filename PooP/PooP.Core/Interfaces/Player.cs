using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;
using PooP.Core.Data;

namespace PooP.Core.Interfaces
{
    public interface Player
    {
        Race Race
        {
            get;
            set;
        }
        string Name
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

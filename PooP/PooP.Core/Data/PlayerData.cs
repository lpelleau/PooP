using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Data.Races;
using PooP.Core.Interfaces;
using PooP.Core.Implementation;

namespace PooP.Core.Data
{
    [Serializable]
    public class PlayerData
    {
        public RaceData Race
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public bool Fst
        {
            get;
            set;
        }

        public Player ToPlayer()
        {
            return new PlayerImpl(this);
        }
    }
}

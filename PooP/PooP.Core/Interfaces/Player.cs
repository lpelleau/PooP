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
        PlayerData ToData();

        PlayerData ToData(bool FstP);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;

namespace PooP.Core.Interfaces.Maps
{
    public interface Tile
    {
        bool available(Race Race);
    }
}

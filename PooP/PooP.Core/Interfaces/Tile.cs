using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP
{
    public interface Tile
    {
        bool available(Race Race);

        Unit getBestDefender();
    }
}

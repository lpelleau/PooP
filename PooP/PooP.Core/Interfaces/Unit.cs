using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP
{
    public interface Unit
    {
        void attack(Tile Tile);

        bool canAttack(Tile Tile);

        int getVictoryPoints();

        bool moveTo(Tile Tile);
    }
}

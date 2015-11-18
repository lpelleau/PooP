using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public interface Unit
    {
        int LifePoints
        {
            get;
            set;
        }

        Race Race
        {
            get;
            set;
        }

        PooP.Core.Position Position
        {
            get;
            set;
        }

        double MovePoints
        {
            get;
            set;
        }

        bool canAttack(PooP.Core.Position Tile);

        int getVictoryPoints();

        double getMoveCost(PooP.Core.Position Tile);

        bool canMoveTo(PooP.Core.Position Target);

        public UnitData ToData();
    }
}

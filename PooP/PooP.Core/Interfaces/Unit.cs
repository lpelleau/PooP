using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Ressource;
using PooP.Core.Interfaces.Races;
using PooP.Core.Data;

namespace PooP.Core.Interfaces
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

        Position Position
        {
            get;
            set;
        }

        double MovePoints
        {
            get;
            set;
        }

        bool canAttack(Position Tile);

        int getVictoryPoints();

        double getMoveCost(Position Tile);

        bool canMoveTo(Position Target);

        UnitData ToData();
    }
}

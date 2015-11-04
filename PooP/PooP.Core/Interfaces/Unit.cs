﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP
{
    public interface Unit
    {
        int LifePoints
        {
            get;
            set;
        }

        Tile Tile
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

        bool canAttack(Tile Tile);

        int getVictoryPoints();

        double getMoveCost(Tile Tile);

        bool canMoveTo(Tile Target);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class UnitImpl : Unit
    {
        public int LifePoints
        {
            get;
            set;
        }

        public Tile Tile
        {
            get;
            set;
        }

        public Race Race
        {
            get;
            set;
        }

        public Position Position
        {
            get;
            set;
        }

        public int MovePoints
        {
            get;
            set;
        }

        public int getVictoryPoints()
        {
            throw new System.NotImplementedException();
        }

        public bool canAttack(Tile dest)
        {
            throw new System.NotImplementedException();
        }

        public int getMoveCost(Tile Tile)
        {
            throw new System.NotImplementedException();
        }
    }
}

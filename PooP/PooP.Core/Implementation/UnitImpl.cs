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

        public TileFactory Tile
        {
            get;
            set;
        }

        public Position Position
        {
            get;
            set;
        }

        public Race Race
        {
            get;
            set;
        }

        public int getVictoryPoints()
        {
            throw new System.NotImplementedException();
        }

        public void attack(Tile dest)
        {
            throw new System.NotImplementedException();
        }

        public bool moveTo(Tile dest)
        {
            throw new System.NotImplementedException();
        }

        public bool canAttack(Tile dest)
        {
            throw new System.NotImplementedException();
        }
    }
}

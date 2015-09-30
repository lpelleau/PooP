using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class Unit
    {
        public int LifePoints
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TileFactory Tile
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Position Position
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
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

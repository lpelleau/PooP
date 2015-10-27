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
                return LifePoints;
            }
            set
            {
                LifePoints = value;
            }
        }

        public TileFactory Tile
        {
            get
            {
                return Tile;
            }
            set
            {
                Tile = value;
            }
        }

        public Position Position
        {
            get
            {
                return Position;
            }
            set
            {
                Position = value;
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

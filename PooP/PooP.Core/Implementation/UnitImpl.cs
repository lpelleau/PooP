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

        public double MovePoints
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

        public double getMoveCost(Tile Target)
        {
            if (this.Race.GetType().Name == "Elf" && Target.GetType().Name == "Mountain")
            {
                return 2;
            }
            else if (this.Race.GetType().Name == "Orc" && Target.GetType().Name == "Plain")
            {
                return 0.5;
            }
            return this.Race.AttackDistance;
            throw new System.NotImplementedException();
        }

        public bool canMoveTo(Tile Target)
        {
            return (this.getMoveCost(Target) < this.MovePoints) && (this.Race.GetType().Name != "Human" || Target.GetType().Name != "Water");
        }
    }
}

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
            if (this.Race.GetType().Name == "Humain" && this.Tile.GetType().Name == "Water")
            {
                return 0;
            }
            else if (this.Race.GetType().Name == "Elf")
            {
                if (this.Tile.GetType().Name == "Mountain")
                {
                    return 0;
                }
                else if (this.Tile.GetType().Name == "Forest")
                {
                    return 3;
                }
            }
            else if (this.Race.GetType().Name == "Orc" && this.Tile.GetType().Name == "Mountain")
            {
                return 2;
            }
            return 1;
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
        }

        public bool canMoveTo(Tile Target)
        {
            return (this.getMoveCost(Target) < this.MovePoints) && (this.Race.GetType().Name != "Human" || Target.GetType().Name != "Water");
        }
    }
}

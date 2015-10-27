using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public abstract class Race
    {
        public int Life
        {
            get
            {
                return Life;
            }
            set
            {
                Life = value;
            }
        }

        public int Attack
        {
            get
            {
                return Attack;
            }
            set
            {
                Attack = value;
            }
        }

        public int Defence
        {
            get
            {
                return Defence;
            }
            set
            {
                Defence = value;
            }
        }

        public int AttackDistance
        {
            get
            {
                return AttackDistance;
            }
            set
            {
                AttackDistance = value;
            }
        }

        public Player Player
        {
            get
            {
                return Player;
            }
            set
            {
                Player = value;
            }
        }

        public List<Unit> Units
        {
            get
            {
                return Units;
            }
            set
            {
                Units = value;
            }
        }

        public abstract int getVictoryPoints();

        public abstract bool hasUnits();

        public void getRace(string raceName)
        {
            throw new System.NotImplementedException();
        }
    }
}

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
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Attack
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Defence
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int AttackDistance
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Player Player
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<Unit> Units
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
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

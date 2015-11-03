using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public abstract class Race
    {
        protected Race()
        {
        }
        public int Life
        {
            get;
            protected set;
        }

        public int Attack
        {
            get;
            protected set;
        }

        public int Defence
        {
            get;
            protected set;
        }

        public int AttackDistance
        {
            get;
            protected set;
        }

        public Player Player
        {
            get;
            set;
        }

        public List<Unit> Units
        {
            get;
            set;
        }

        public abstract int getVictoryPoints();

        public abstract bool hasUnits();
    }
}

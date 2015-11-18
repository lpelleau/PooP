using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;
using PooP.Core.Interfaces;
using PooP.Core.Data.Races;

namespace PooP.Core.Implementation.Races
{
    public class Human : Race
    {
        public Human()
        {
            Attack = 6;
            AttackDistance = 1;
            Defence = 3;
            Life = 15;
            MoveDistance = 1;
        }

        public int MoveDistance
        {
            get;
            set;
        }
        public int Life
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defence
        {
            get;
            set;
        }

        public int AttackDistance
        {
            get;
            set;
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

        public bool hasUnits()
        {
            throw new NotImplementedException();
        }
        public int getVictoryPoints()
        {
            return Units.FindAll(e => e.LifePoints > 0).Sum(e => e.getVictoryPoints());
        }

        public RaceData ToData()
        {
            return new HumanData
            {
                Units = this.Units.ConvertAll(u => u.ToData())
            };
        }
    }

    public class Elf : Race
    {
        private Elf()
        {
            Attack = 4;
            AttackDistance = 2;
            Defence = 3;
            Life = 12;
            MoveDistance = 1;
        }

        public int MoveDistance
        {
            get;
            set;
        }
        public int Life
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defence
        {
            get;
            set;
        }

        public int AttackDistance
        {
            get;
            set;
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

        public bool hasUnits()
        {
            throw new NotImplementedException();
        }
        public int getVictoryPoints()
        {
            return Units.FindAll(e => e.LifePoints > 0).Sum(e => e.getVictoryPoints());
        }

        public RaceData ToData()
        {
            return new HumanData
            {
                Units = this.Units.ConvertAll(u => u.ToData())
            };
        }
    }

    public class Orc : Race
    {
        private Orc()
        {
            Attack = 5;
            AttackDistance = 2; // Carreful, AccackDistance = 1 if not on mountain tile......
            Defence = 2;
            Life = 17;
            MoveDistance = 1;
        }

        public int MoveDistance
        {
            get;
            set;
        }
        public int Life
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defence
        {
            get;
            set;
        }

        public int AttackDistance
        {
            get;
            set;
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

        public bool hasUnits()
        {
            throw new NotImplementedException();
        }
        public int getVictoryPoints()
        {
            return Units.FindAll(e => e.LifePoints > 0).Sum(e => e.getVictoryPoints());
        }

        public RaceData ToData()
        {
            return new HumanData
            {
                Units = this.Units.ConvertAll(u => u.ToData())
            };
        }
    }
}

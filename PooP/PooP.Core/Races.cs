using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class Human : Race
    {
        private Human()
        {
            Attack = 6;
            AttackDistance = 1;
            Defence = 3;
            Life = 15;
        }
        private static Race instance;
        public static Race Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Human();
                }
                return instance;
            }
        }

        public override bool hasUnits()
        {
            throw new NotImplementedException();
        }
        public override int getVictoryPoints()
        {
            throw new NotImplementedException();
        }
    }

    public class Elf : Race
    {
        private Elf()
        {
            Attack = 4;
            AttackDistance = 1; // Carreful, AccackDistance = 2 if in the same direction.....
            Defence = 3;
            Life = 12;
        }
        private static Race instance;
        public static Race Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Elf();
                }
                return instance;
            }
        }
        public override bool hasUnits()
        {
            throw new NotImplementedException();
        }
        public override int getVictoryPoints()
        {
            throw new NotImplementedException();
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
        }
        private static Race instance;
        public static Race Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Orc();
                }
                return instance;
            }
        }
        public override bool hasUnits()
        {
            throw new NotImplementedException();
        }
        public override int getVictoryPoints()
        {
            throw new NotImplementedException();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class Human : Race
    {
        public Human()
        {
            Attack = 6;
            AttackDistance = 1;
            Defence = 3;
            Life = 15;
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
            AttackDistance = 2;
            Defence = 3;
            Life = 12;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;

namespace PooP.Core.Implementation.Races
{
    public class RaceFactory
    {
        public Race Human
        {
            get;
            set;
        }

        public Race Orc
        {
            get;
            set;
        }

        public Race Elf
        {
            get;
            set;
        }
    
        public static Race getRace(string raceName)
        {
            throw new System.NotImplementedException();
        }
    }
}

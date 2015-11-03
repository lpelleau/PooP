using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
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
    
        public Race getRace(string raceName)
        {
            throw new System.NotImplementedException();
        }
    }
}

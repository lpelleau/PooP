using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PooP.Core.Interfaces.Races;
using PooP.Core.Implementation.Races;

namespace PooP.Core.Data.Races
{
    public class RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }

        public string Race
        {
            get;
            set;
        }

        public Race ToRace()
        {
            Race r = null;
            switch(Race.ToLower()) {
                case "human": new Human(); break;
                case "elf":   new Elf();   break;
                case "orc":   new Orc();   break;
            }
            r.Units = Units.ConvertAll(u => u.ToUnit());
            return r;
        }
    }
}

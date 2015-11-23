using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;
using PooP.Core.Implementation.Races;

namespace PooP.Core.Data.Races
{
    [Serializable]
    public class HumanData : RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }

        public Race ToRace()
        {
            Race r = new Human();
            r.Units = Units.ConvertAll(u => u.ToUnit());
            return r;
        }
    }

    [Serializable]
    public class ElfData : RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }

        public Race ToRace()
        {
            Race r = new Elf();
            r.Units = Units.ConvertAll(u => u.ToUnit());
            return r;
        }
    }

    [Serializable]
    public class OrcData : RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }

        public Race ToRace()
        {
            Race r = new Orc();
            r.Units = Units.ConvertAll(u => u.ToUnit());
            return r;
        }
    }
}

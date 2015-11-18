using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;

namespace PooP.Core.Data.Races
{
    public class HumanData : RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }
    }

    public class ElfData : RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }
    }

    public class OrcData : RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class HumanData : RaceData
    {
        public List<UnitData> Units
        {
            get;
            set;
        }
    }

    public class ElfData : Race
    {
        public List<UnitData> Units
        {
            get;
            set;
        }
    }

    public class OrcData : Race
    {
        public List<UnitData> Units
        {
            get;
            set;
        }
    }
}

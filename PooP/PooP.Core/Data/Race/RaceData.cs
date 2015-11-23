using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Data.Races
{
    [Serializable]
    public interface RaceData
    {
        List<UnitData> Units
        {
            get;
            set;
        }
    }
}

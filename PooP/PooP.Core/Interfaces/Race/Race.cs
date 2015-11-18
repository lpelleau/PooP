using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Data.Races;

namespace PooP.Core.Interfaces.Races
{
    public interface Race
    {
        int Life
        {
            get;
            set;
        }

        int Attack
        {
            get;
            set;
        }

        int Defence
        {
            get;
            set;
        }

        int AttackDistance
        {
            get;
            set;
        }

        Player Player
        {
            get;
            set;
        }

        List<Unit> Units
        {
            get;
            set;
        }

        int MoveDistance
        {
            get;
            set;
        }
        int getVictoryPoints();

        bool hasUnits();

        RaceData ToData();
    }
}

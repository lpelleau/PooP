using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;
using PooP.Core.Exceptions;

namespace PooP.Core.Implementation.Races
{
    public class RaceFactoryImpl
    {
        public static Human HumanRace = new Human();

        public static Orc OrcRace = new Orc();

        public static Elf ElfRace = new Elf();

        public static Race getRace(string raceName)
        {
            switch (raceName.ToLower())
            {
                case "human": return HumanRace;
                case "orc": return OrcRace;
                case "elf": return ElfRace;
                default: throw new NotExistingRaceException(raceName);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;
using PooP.Core.Exceptions;

namespace PooP.Core.Implementation.Races
{
    /// <summary>
    /// Creates and gives the instances for races
    /// </summary>
    public class RaceFactoryImpl
    {
        // Races
        public static Human HumanRace = new Human();

        public static Orc OrcRace = new Orc();

        public static Elf ElfRace = new Elf();

        /// <summary>
        /// Gets the race for a given name
        /// </summary>
        /// <param name="raceName">Name of the race to use</param>
        /// <returns>The race corresponding to that name</returns>
        public static Race getRace(string raceName)
        {
            switch (raceName.ToLower())
            {
                case "human": return HumanRace;
                case "orc": return OrcRace;
                case "elf": return ElfRace;
                default: throw new RaceException(raceName);
            }
        }
    }
}

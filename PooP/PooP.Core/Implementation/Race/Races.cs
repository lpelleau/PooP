using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces.Races;
using PooP.Core.Interfaces;
using PooP.Core.Data.Races;

namespace PooP.Core.Implementation.Races
{
    /// <summary>
    /// Represents the human race
    /// </summary>
    public class Human : Race
    {
        /// <summary>
        /// Constructor
        /// By being internal, it is only accessible to this project
        /// </summary>
        internal Human()
        {
            Attack = 6;
            AttackDistance = 1;
            Defence = 3;
            Life = 15;
            MoveDistance = 2;
            Units = new List<Unit>();
        }

        /// <summary>
        /// Loads a human race from data
        /// </summary>
        /// <param name="data">Datas to load</param>
        public Human(RaceData data)
        {
            Units = data.Units.ConvertAll(u => u.ToUnit());
        }

        /// <summary>
        /// Move distance of a human
        /// </summary>
        public int MoveDistance
        {
            get;
            set;
        }

        /// <summary>
        /// Maximal life for a human
        /// </summary>
        public int Life
        {
            get;
            set;
        }

        /// <summary>
        /// Attack points for a human
        /// </summary>
        public int Attack
        {
            get;
            set;
        }

        /// <summary>
        /// Defence points for a human
        /// </summary>
        public int Defence
        {
            get;
            set;
        }

        /// <summary>
        /// AttackDistance for a human
        /// </summary>
        public int AttackDistance
        {
            get;
            set;
        }

        /// <summary>
        /// Player associated to the human race
        /// </summary>
        public Player Player
        {
            get;
            set;
        }

        /// <summary>
        /// Humans standing
        /// </summary>
        public List<Unit> Units
        {
            get;
            set;
        }

        /// <summary>
        /// Tests if there are still humans standing
        /// </summary>
        /// <returns>true if there is at least oe human, false otherwise</returns>
        public bool hasUnits()
        {
            return Units.Count() > 0;
        }

        /// <summary>
        /// Computes how many victory points the humans represent
        /// </summary>
        /// <returns>Humans' victory points</returns>
        public int getVictoryPoints()
        {
            return Units.FindAll(e => e.LifePoints > 0).Sum(e => e.getVictoryPoints());
        }

        /// <summary>
        /// Transforms the human race into datas
        /// </summary>
        /// <returns>A data human race object</returns>
        public RaceData ToData()
        {
            return new RaceData
            {
                RaceName = "Human",
                Units = this.Units.ConvertAll(u => u.ToData())
            };
        }

        /// <summary>
        /// Gives a string representation
        /// </summary>
        /// <returns>"Human"</returns>
        public override string ToString()
        {
            return "Human";
        }
    }

    /// <summary>
    /// Implements the elf race
    /// </summary>
    public class Elf : Race
    {
        /// <summary>
        /// Constructor
        /// It is internal so that only the factory can create it
        /// </summary>
        internal Elf()
        {
            Attack = 4;
            AttackDistance = 2;
            Defence = 3;
            Life = 12;
            MoveDistance = 2;
            Units = new List<Unit>();
        }

        /// <summary>
        /// Loads the elf race from a file
        /// </summary>
        /// <param name="data">Datas to load</param>
        public Elf(RaceData data)
        {
            Units = data.Units.ConvertAll(u => u.ToUnit());
        }

        /// <summary>
        /// Move distance possible for an elf
        /// </summary>
        public int MoveDistance
        {
            get;
            set;
        }

        /// <summary>
        /// Maximal life points for elves
        /// </summary>
        public int Life
        {
            get;
            set;
        }

        /// <summary>
        /// Attack points for elves
        /// </summary>
        public int Attack
        {
            get;
            set;
        }

        /// <summary>
        /// Defence points for elves
        /// </summary>
        public int Defence
        {
            get;
            set;
        }

        /// <summary>
        /// Attack distances for elves
        /// </summary>
        public int AttackDistance
        {
            get;
            set;
        }

        /// <summary>
        /// The player that chose the elf race
        /// </summary>
        public Player Player
        {
            get;
            set;
        }

        /// <summary>
        /// Standing elves
        /// </summary>
        public List<Unit> Units
        {
            get;
            set;
        }

        /// <summary>
        /// Tests if there are still elves standing
        /// </summary>
        /// <returns>true if there is at least one living elf, false otherwise</returns>
        public bool hasUnits()
        {
            return Units.Count() > 0;
        }

        /// <summary>
        /// Computes the points the elves give to the player
        /// </summary>
        /// <returns>Victory points for the elf race</returns>
        public int getVictoryPoints()
        {
            return Units.FindAll(e => e.LifePoints > 0).Sum(e => e.getVictoryPoints());
        }

        /// <summary>
        /// Transforms the elf race into data
        /// </summary>
        /// <returns>Tha data object</returns>
        public RaceData ToData()
        {
            return new RaceData
            {
                RaceName = "Elf",
                Units = this.Units.ConvertAll(u => u.ToData())
            };
        }

        /// <summary>
        /// Gives a string representation
        /// </summary>
        /// <returns>"Elf"</returns>
        public override string ToString()
        {
            return "Elf";
        }
    }

    /// <summary>
    /// Implements the orc race
    /// </summary>
    public class Orc : Race
    {
        /// <summary>
        /// Creates the orc race
        /// It is internal so that only the factory can access it
        /// </summary>
        internal Orc()
        {
            Attack = 5;
            AttackDistance = 1;
            Defence = 2;
            Life = 17;
            MoveDistance = 2;
            Units = new List<Unit>();
        }

        /// <summary>
        /// Loads the orc race from data
        /// </summary>
        /// <param name="data">Datas to load</param>
        public Orc(RaceData data)
        {
            Units = data.Units.ConvertAll(u => u.ToUnit());
        }

        /// <summary>
        /// Move distance for the orcs
        /// </summary>
        public int MoveDistance
        {
            get;
            set;
        }

        /// <summary>
        /// Maximal life points for orcs
        /// </summary>
        public int Life
        {
            get;
            set;
        }

        /// <summary>
        /// Attack points for orcs
        /// </summary>
        public int Attack
        {
            get;
            set;
        }

        /// <summary>
        /// Defence points for orcs
        /// </summary>
        public int Defence
        {
            get;
            set;
        }

        /// <summary>
        /// Attack distance for orcs
        /// </summary>
        public int AttackDistance
        {
            get;
            set;
        }

        /// <summary>
        /// The player that plays the orc race
        /// </summary>
        public Player Player
        {
            get;
            set;
        }

        /// <summary>
        /// Standing orc units
        /// </summary>
        public List<Unit> Units
        {
            get;
            set;
        }

        /// <summary>
        /// Tests if there are still orcs standing
        /// </summary>
        /// <returns>true if there is at least one orc standing, false otherwise</returns>
        public bool hasUnits()
        {
            return Units.Count() > 0;
        }

        /// <summary>
        /// Computes the victory points for the orc race
        /// </summary>
        /// <returns>The number of points for all orcs</returns>
        public int getVictoryPoints()
        {
            return Units.FindAll(e => e.LifePoints > 0).Sum(e => e.getVictoryPoints());
        }

        /// <summary>
        /// Transforms the orc race into datas
        /// </summary>
        /// <returns>The data object</returns>
        public RaceData ToData()
        {
            return new RaceData
            {
                RaceName = "Orc",
                Units = this.Units.ConvertAll(u => u.ToData())
            };
        }

        /// <summary>
        /// Gives a string representation
        /// </summary>
        /// <returns>"Orc"</returns>
        public override string ToString()
        {
            return "Orc";
        }
    }
}

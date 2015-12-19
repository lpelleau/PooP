using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Races;
using PooP.Core.Interfaces.Maps;
using PooP.Core.Implementation.Maps;
using PooP.Core.Ressource;
using PooP.Core.Data;
using PooP.Core.Implementation.Games;

namespace PooP.Core.Implementation
{
    /// <summary>
    /// Implements a Unit
    /// </summary>
    public class UnitImpl : Unit
    {
        /// <summary>
        /// Creates a Unit from a data unit
        /// </summary>
        /// <param name="data">Datas to load</param>
        public UnitImpl(UnitData data)
        {
            LifePoints = data.LifePoints;
            MovePoints = data.MovePoints;
            Position = data.Position;
        }

        /// <summary>
        /// Creates a Unit with a race and a position
        /// </summary>
        /// <param name="r">Unit's race</param>
        /// <param name="p">Position of the unit for the first turn</param>
        public UnitImpl(Race r, Position p)
        {
            Race = r;
            LifePoints = r.Life;
            Position = p;
            MovePoints = 2.0;
        }

        /// <summary>
        /// Current life points of the unit
        /// </summary>
        public int LifePoints
        {
            get;
            set;
        }

        /// <summary>
        /// Unit's race
        /// </summary>
        public Race Race
        {
            get;
            set;
        }

        /// <summary>
        /// Current position of the unit
        /// </summary>
        public Position Position
        {
            get;
            set;
        }

        /// <summary>
        /// Number of points the unit can use to move to different tiles
        /// </summary>
        public double MovePoints
        {
            get;
            set;
        }

        /// <summary>
        /// Computes how many victory points the unit gives to the player
        /// </summary>
        /// <returns>Victory points, in a 0-3 range</returns>
        public int getVictoryPoints()
        {
            if (Race.GetType().Name == "Human")
            {
                if (GameBuilder.CURRENTGAME.Map.getTileAt(Position).GetType().Name == "Water")
                    return 0;
                if (GameBuilder.CURRENTGAME.Map.getTileAt(Position).GetType().Name == "Plain")
                    return 2;
            }
            if (Race.GetType().Name == "Elf")
            {
                if (GameBuilder.CURRENTGAME.Map.getTileAt(Position).GetType().Name == "Mountain")
                    return 0;

                if (GameBuilder.CURRENTGAME.Map.getTileAt(Position).GetType().Name == "Forest")
                    return 3;
            }
            if (Race.GetType().Name == "Orc" && GameBuilder.CURRENTGAME.Map.getTileAt(Position).GetType().Name == "Mountain")
                return 2;

            return 1;
        }

        /// <summary>
        /// Tells if a given position can be attacked by this unit or not
        /// </summary>
        /// <param name="dest">Position to attack</param>
        /// <returns>true if the unit has the needed points to attack this position</returns>
        public bool canAttack(Position dest)
        {
            return (getMoveCost(dest) - Int16.MaxValue / 2) <= MovePoints + Race.AttackDistance
                && (dest.XPosition == Position.XPosition || dest.YPosition == Position.YPosition)
                && GameBuilder.CURRENTGAME.Map.IsOccupied(dest, Race)
                && (Race.GetType().Name == "Human" || GameBuilder.CURRENTGAME.Map.getTileAt(dest).GetType().Name != "Water");
        }

        /// <summary>
        /// Tests if the unit can defend itself from an attack by a certain position
        /// </summary>
        /// <param name="Attackers">Attackers' position</param>
        /// <returns>true if the unit has enough attack distance, false else</returns>
        public bool canDefendAgainst(Position Attackers)
        {
            return (getMoveCost(Attackers) - (Int16.MaxValue / 2)) <= Race.AttackDistance;
        }

        /// <summary>
        /// Computes the needed move points to go to a certain position
        /// </summary>
        /// <param name="Target">Position to reach</param>
        /// <returns>The number of needed points</returns>
        private double getMoveCostFromTile(Position TargetPos)
        {
            double res = 0;
            Tile Target = GameBuilder.CURRENTGAME.Map.getTileAt(TargetPos);

            if (GameBuilder.CURRENTGAME.Map.IsOccupied(TargetPos, this.Race))
                res = Int16.MaxValue / 2;
            if (Race.GetType().Name != "Human" && Target.GetType().Name == "Water")
                res += Int16.MaxValue / 2;
            else if (Race.GetType().Name == "Elf" && Target.GetType().Name == "Mountain")
                res += 2;
            else if (Race.GetType().Name == "Orc" && Target.GetType().Name == "Plain")
                res += 0.5;
            else res += 1;
            return res;
        }

        /// <summary>
        /// Computes the number of needed points to move to a given position
        /// This method uses Dijkstra algorithm to compute the needed points, starting from the beginning position
        /// </summary>
        /// <param name="Target">Position to reach</param>
        /// <param name="Start">Starting position</param>
        /// <returns>The number of points needed to move to the given position</returns>
        public double getMoveCostFromTo(Position Start, Position Target)
        {
            double totalCost = 0;
            // Moving on Y axis
            if (Start.XPosition == Target.XPosition)
                // Moving forward on Y axis
                if (Start.YPosition < Target.YPosition)
                    for (int i = Start.YPosition + 1; i <= Target.YPosition; i++)
                        totalCost += getMoveCostFromTile(new Position(Target.XPosition, i));
                // Moving backward on Y axis
                else
                    for (int i = Start.YPosition - 1; i >= Target.YPosition; i--)
                        totalCost += getMoveCostFromTile(new Position(Target.XPosition, i));
            // Moving on X axis
            else if (Start.YPosition == Target.YPosition)
                // Moving forward on X axis
                if (Start.XPosition < Target.XPosition)
                    for (int i = Start.XPosition + 1; i <= Target.XPosition; i++)
                        totalCost += getMoveCostFromTile(new Position(i, Target.YPosition));
                // Moving backward on X axis
                else
                    for (int i = Start.XPosition - 1; i >= Target.XPosition; i--)
                        totalCost += getMoveCostFromTile(new Position(i, Target.YPosition));
            // Find the correct path
            else
            {
                // Try moving to another tile and test
                List<double> possibleCosts = new List<double>();
                Position[] TestedPaths = new Position[4] {  new Position(Math.Min(Start.XPosition + 1,GameBuilder.CURRENTGAME.Map.Width), Start.YPosition),
                                                            new Position(Start.XPosition, Math.Min(Start.YPosition + 1,GameBuilder.CURRENTGAME.Map.Height)),
                                                            new Position(Math.Max(Start.XPosition - 1,0), Start.YPosition),
                                                            new Position(Start.XPosition, Math.Max(Start.YPosition - 1,0))};
                /*
                 * Start (S) and Target (T) are like :
                 *  S   A  ... ...
                 *  B  ... ... ...
                 * ... ... ... ...
                 * ... ... ...  T
                 * => Test A (TestedPaths[0]) and B (TestedPaths[1])
                */
                if (Start.XPosition < Target.XPosition && Start.YPosition < Target.YPosition)
                {
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[0]) + getMoveCostFromTo(TestedPaths[0], Target));
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[1]) + getMoveCostFromTo(TestedPaths[1], Target));
                }
                /*
                 * Start (S) and Target (T) are like :
                 * ... ... ...  T
                 * ... ... ... ...
                 *  B  ... ... ...
                 *  S   A  ... ...
                 * => Test A (TestedPaths[0]) and B (TestedPaths[3])
                */
                else if (Start.XPosition < Target.XPosition && Start.YPosition > Target.YPosition)
                {
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[0]) + getMoveCostFromTo(TestedPaths[0], Target));
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[3]) + getMoveCostFromTo(TestedPaths[3], Target));
                }
                /*
                 * Start (S) and Target (T) are like :
                 *  T  ... ... ...
                 * ... ... ... ...
                 * ... ... ...  B
                 * ... ...  A   S
                 * => Test A (TestedPaths[2]) and B (TestedPaths[3])
                */
                else if (Start.XPosition > Target.XPosition && Start.YPosition > Target.YPosition)
                {
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[2]) + getMoveCostFromTo(TestedPaths[2], Target));
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[3]) + getMoveCostFromTo(TestedPaths[3], Target));
                }
                /*
                 * Start (S) and Target (T) are like :
                 * ... ...  A   S
                 * ... ... ...  B
                 * ... ... ... ...
                 *  T  ... ... ...
                 * => Test A (TestedPaths[2]) and B (TestedPaths[1])
                */
                else
                {
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[1]) + getMoveCostFromTo(TestedPaths[1], Target));
                    possibleCosts.Add(getMoveCostFromTo(Start, TestedPaths[2]) + getMoveCostFromTo(TestedPaths[2], Target));
                }

                totalCost += possibleCosts.Min();
            }
            return totalCost;
        }

        public double getMoveCost(Position Target)
        {
            return getMoveCostFromTo(this.Position, Target);
        }

        /// <summary>
        /// Tells if the unit can move to a given tile through the position
        /// </summary>
        /// <param name="Target">Target position</param>
        /// <returns>true if the unit can move to the given position, false otherwise</returns>
        public bool canMoveTo(Position Target)
        {
            return (!Target.Equals(Position)
                && getMoveCost(Target) <= MovePoints) && (Race.GetType().Name == "Human" || GameBuilder.CURRENTGAME.Map.getTileAt(Target).GetType().Name != "Water")
                && !GameBuilder.CURRENTGAME.Map.IsOccupied(Target, Race);
        }

        /// <summary>
        /// Transforms a unit into data
        /// </summary>
        /// <returns>The data object</returns>
        public UnitData ToData()
        {
            return new UnitData
            {
                LifePoints = this.LifePoints,
                MovePoints = this.MovePoints,
                Position = this.Position
            };
        }
    }
}

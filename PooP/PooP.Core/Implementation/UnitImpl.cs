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
            MovePoints = 0;
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
        /// Tells if a unit can reach a given position
        /// </summary>
        /// <param name="Target">Position to reach</param>
        /// <returns>true if the unit has the needed points to move to this position</returns>
        private bool reachable(Position Target)
        {
            return (Target.XPosition == Position.YPosition || Target.YPosition == Position.YPosition)
                && (getMoveCost(Target) < MovePoints) && (Race.GetType().Name == "Human" || GameBuilder.CURRENTGAME.Map.getTileAt(Target).GetType().Name != "Water");
        }

        /// <summary>
        /// Tells if a given position can be attacked by this unit or not
        /// </summary>
        /// <param name="dest">Position to attack</param>
        /// <returns>true if the unit has the needed points to attack this position</returns>
        public bool canAttack(Position dest)
        {
            return reachable(dest) && GameBuilder.CURRENTGAME.Map.IsOccupied(dest,Race);
        }

        /// <summary>
        /// Computes the needed move points to go to a certain position
        /// </summary>
        /// <param name="Target">Position to reach</param>
        /// <returns>The number of needed points</returns>
        private double getMoveCostFromTile(Tile Target)
        {
            if (Race.GetType().Name == "Elf" && Target.GetType().Name == "Mountain")
            {
                return 2;
            }
            else if (Race.GetType().Name == "Orc" && Target.GetType().Name == "Plain")
            {
                return 0.5;
            }
            return 1;
        }

        /// <summary>
        /// Computes the number of needed points to move to a given position
        /// (This version only computes moving vertically OR horizontally)
        /// </summary>
        /// <param name="Target">Position to reach</param>
        /// <returns>The number of points needed to move to the given position</returns>
        public double getMoveCost(Position Target)
        {
            double totalCost = 0;
            // Moving on Y axis
            if (Position.XPosition == Target.XPosition)
                // Moving forward on Y axis
                if (Position.YPosition < Target.YPosition)
                    for (int i = Position.YPosition + 1; i <= Target.YPosition; i++)
                        totalCost += getMoveCostFromTile(GameBuilder.CURRENTGAME.Map.getTileAt(new Position(Target.XPosition, i)));
                // Moving backward on Y axis
                else
                    for (int i = Position.YPosition - 1; i >= Target.YPosition; i--)
                        totalCost += getMoveCostFromTile(GameBuilder.CURRENTGAME.Map.getTileAt(new Position(Target.XPosition, i)));
            // Moving on X axis
            else
                // Moving forward on X axis
                if (Position.XPosition < Target.XPosition)
                    for (int i = Position.XPosition + 1; i <= Target.XPosition; i++)
                        totalCost += getMoveCostFromTile(GameBuilder.CURRENTGAME.Map.getTileAt(new Position(i, Target.YPosition)));
                // Moving backward on X axis
                else
                    for (int i = Position.XPosition - 1; i >= Target.XPosition; i--)
                        totalCost += getMoveCostFromTile(GameBuilder.CURRENTGAME.Map.getTileAt(new Position(i, Target.YPosition)));
            return totalCost;
        }

        /// <summary>
        /// Tells if the unit can move to a given tile through the position
        /// </summary>
        /// <param name="Target">Target position</param>
        /// <returns>true if the unit can move to the given position, false otherwise</returns>
        public bool canMoveTo(Position Target)
        {
            return reachable(Target) && !GameBuilder.CURRENTGAME.Map.IsOccupied(Target,Race);
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

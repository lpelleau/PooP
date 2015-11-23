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
    public class UnitImpl : Unit
    {
        public UnitImpl(UnitData data)
        {
            LifePoints = data.LifePoints;
            MovePoints = data.MovePoints;
            Position = data.Position;
        }

        public int LifePoints
        {
            get;
            set;
        }

        public Race Race
        {
            get;
            set;
        }

        public Position Position
        {
            get;
            set;
        }

        public double MovePoints
        {
            get;
            set;
        }

        public int getVictoryPoints()
        {
            if (Race.GetType().Name == "Humain" && GameImpl.CURRENTGAME.Tiles.getTileAt(Position).GetType().Name == "Water")
            {
                return 0;
            }
            else if (Race.GetType().Name == "Elf")
            {
                if (GameImpl.CURRENTGAME.Tiles.getTileAt(Position).GetType().Name == "Mountain")
                {
                    return 0;
                }
                else if (GameImpl.CURRENTGAME.Tiles.getTileAt(Position).GetType().Name == "Forest")
                {
                    return 3;
                }
            }
            else if (Race.GetType().Name == "Orc" && GameImpl.CURRENTGAME.Tiles.getTileAt(Position).GetType().Name == "Mountain")
            {
                return 2;
            }
            return 1;
        }

        // Tells if a unit can reach a given position
        private Boolean reachable(Position Target)
        {
            return (Target.XPosition == Position.YPosition || Target.YPosition == Position.YPosition)
                && (getMoveCost(Target) < MovePoints) && (Race.GetType().Name != "Human" || Target.GetType().Name != "Water");
        }

        // Tells if a given position can be attacked by this unit or not
        public bool canAttack(Position dest)
        {
            return reachable(dest) && GameImpl.CURRENTGAME.Tiles.IsOccupied(dest);
        }

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
            return Race.AttackDistance;
        }

        // Computes the number of needed points to move to a given position
        // (This version only computes moving vertically OR horizontally)
        public double getMoveCost(Position Target)
        {
            double totalCost = 0;
            // Moving on Y axis
            if (Position.XPosition == Target.XPosition)
                // Moving forward on Y axis
                if (Position.YPosition < Target.YPosition)
                    for (int i = Position.XPosition + 1; i <= Target.XPosition; i++)
                        totalCost += getMoveCostFromTile(GameImpl.CURRENTGAME.Tiles.getTileAt(new Position(i, Target.YPosition)));
                // Moving backward on Y axis
                else
                    for (int i = Position.XPosition - 1; i >= Target.XPosition; i--)
                        totalCost += getMoveCostFromTile(GameImpl.CURRENTGAME.Tiles.getTileAt(new Position(i, Target.YPosition)));
            // Moving on X axis
            else
                // Moving forward on X axis
                if (Position.XPosition < Target.XPosition)
                for (int i = Position.XPosition + 1; i <= Target.XPosition; i++)
                    totalCost += getMoveCostFromTile(GameImpl.CURRENTGAME.Tiles.getTileAt(new Position(Target.XPosition, i)));
            // Moving backward on X axis
            else
                for (int i = Position.XPosition - 1; i >= Target.XPosition; i--)
                    totalCost += getMoveCostFromTile(GameImpl.CURRENTGAME.Tiles.getTileAt(new Position(Target.XPosition, i)));
            return totalCost;
        }

        // Tells if the unit can move to a given tile through the position
        public bool canMoveTo(Position Target)
        {
            return reachable(Target) && !GameImpl.CURRENTGAME.Tiles.IsOccupied(Target);
        }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class UnitImpl : Unit
    {
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
            if (Race.GetType().Name == "Humain" && TileFactory.TILE_GENERATOR.getTileAt(Position).GetType().Name == "Water")
            {
                return 0;
            }
            else if (Race.GetType().Name == "Elf")
            {
                if (TileFactory.TILE_GENERATOR.getTileAt(Position).GetType().Name == "Mountain")
                {
                    return 0;
                }
                else if (TileFactory.TILE_GENERATOR.getTileAt(Position).GetType().Name == "Forest")
                {
                    return 3;
                }
            }
            else if (Race.GetType().Name == "Orc" && TileFactory.TILE_GENERATOR.getTileAt(Position).GetType().Name == "Mountain")
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
            return reachable(dest) && TileFactory.TILE_GENERATOR.IsOccupied(dest);
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
                        totalCost += getMoveCostFromTile(TileFactory.TILE_GENERATOR.getTileAt(new Position(i, Target.YPosition)));
                // Moving backward on Y axis
                else
                    for (int i = Position.XPosition - 1; i >= Target.XPosition; i--)
                        totalCost += getMoveCostFromTile(TileFactory.TILE_GENERATOR.getTileAt(new Position(i, Target.YPosition)));
            // Moving on X axis
            else
                // Moving forward on X axis
                if (Position.XPosition < Target.XPosition)
                for (int i = Position.XPosition + 1; i <= Target.XPosition; i++)
                    totalCost += getMoveCostFromTile(TileFactory.TILE_GENERATOR.getTileAt(new Position(Target.XPosition, i)));
            // Moving backward on X axis
            else
                for (int i = Position.XPosition - 1; i >= Target.XPosition; i--)
                    totalCost += getMoveCostFromTile(TileFactory.TILE_GENERATOR.getTileAt(new Position(Target.XPosition, i)));
            return totalCost;
        }

        // Tells if the unit can move to a given tile through the position
        public bool canMoveTo(Position Target)
        {
            return reachable(Target) && !TileFactory.TILE_GENERATOR.IsOccupied(Target);
        }
    }
}

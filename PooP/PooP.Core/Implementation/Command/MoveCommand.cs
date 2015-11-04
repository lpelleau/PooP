using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core
{
    public class MoveCommand : Command
    {
        private Unit MovedUnit;
        private Tile OldTile;
        private Tile Target;
        private double cost;

        public MoveCommand(Unit UnitToMove, Tile TileToReach)
        {
            MovedUnit = UnitToMove;
            Target = TileToReach;
            OldTile = MovedUnit.Tile;
        }

        public bool canDo()
        {
            return MovedUnit.canMoveTo(Target);
        }

        public void execute()
        {
            // Move the unit to the target
            MovedUnit.Tile = Target;

            // Consumes the needed move points
            cost = MovedUnit.getMoveCost(Target);
            MovedUnit.MovePoints -= cost;
        }

        public void undo()
        {
            // Gives back the needed move points
            MovedUnit.MovePoints += cost;

            // Move the unit back to the old tile
            MovedUnit.Tile = OldTile;
        }

        public void redo()
        {
            this.execute();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Commands;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;

namespace PooP.Core.Implementation.Commands
{
    /// <summary>
    /// Moves a unit to a certain tile
    /// </summary>
    public class MoveCommand : PooP.Core.Interfaces.Commands.Command
    {
        private Unit MovedUnit;
        private Position OldTile;
        private Position Target;
        private double cost;

        /// <summary>
        /// Creates the command to execute
        /// </summary>
        /// <param name="UnitToMove">The unit that shall be moved</param>
        /// <param name="PosToReach">The tile to reach</param>
        public MoveCommand(Unit UnitToMove, Position PosToReach)
        {
            MovedUnit = UnitToMove;
            Target = PosToReach;
            OldTile = MovedUnit.Position;
            
            // Computes the number of needed points
            cost = MovedUnit.getMoveCost(Target);
        }

        /// <summary>
        /// Tests if the unit can move to the tile
        /// </summary>
        /// <returns>true if the unit can go, false otherwise</returns>
        public bool canDo()
        {
            return MovedUnit.canMoveTo(Target);
        }

        /// <summary>
        /// Executes de command
        /// </summary>
        public void execute()
        {
            if (!this.canDo()) throw new IncorrectCommandException();

            // Move the unit to the target
            MovedUnit.Position = Target;

            // Consumes the needed move points
            
            MovedUnit.MovePoints -= cost;
        }

        /// <summary>
        /// Undoes the command
        /// </summary>
        public void undo()
        {
            // Gives back the needed move points
            MovedUnit.MovePoints += cost;

            // Move the unit back to the old tile
            MovedUnit.Position = OldTile;
        }

        /// <summary>
        /// Redoes the command
        /// </summary>
        public void redo()
        {
            this.execute();
        }
    }
}

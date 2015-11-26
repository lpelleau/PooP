using PooP.Core.Implementation.Command;
using PooP.Core.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Implementation.Commands
{
    /// <summary>
    /// Ends a turn
    /// </summary>
    public class EndTurn : PooP.Core.Interfaces.Commands.Command
    {
        /// <summary>
        /// Tests if the turn can be ended
        /// </summary>
        /// <returns>Always return true since a turn can always be ended</returns>
        public bool canDo()
        {
            return true;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public void execute()
        {
            UndoableImpl.DoneCommands.Clear();
            // TO DO : Change the current player
        }

        /// <summary>
        /// Undoes the command
        /// </summary>
        public void undo()
        {
            // Undo is not possible
        }

        /// <summary>
        /// Redoes the command
        /// </summary>
        public void redo()
        {
            // Redo is not possible
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Interfaces.Commands
{
    /// <summary>
    /// Represents a command
    /// </summary>
    public interface Command
    {
        /// <summary>
        /// Tests if a command can be done
        /// </summary>
        /// <returns>true if the command is fireable, false otherwise</returns>
        bool canDo();

        /// <summary>
        /// Executes the command
        /// </summary>
        void execute();

        /// <summary>
        /// Undoes the command
        /// </summary>
        void undo();

        /// <summary>
        /// Redoes the command
        /// </summary>
        void redo();
    }
}

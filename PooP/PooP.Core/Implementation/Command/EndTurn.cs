using PooP.Core.Implementation.Commands;
using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
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
        public static Player winner = null;

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
        /// Deletes the action list, Changes the current player, Decreases the 
        /// </summary>
        public void execute()
        {
            UndoableImpl.DoneCommands.Clear();
            GameBuilder.CURRENTGAME.NumberOfTurns--;
            GameBuilder.CURRENTGAME.IndexOfCurrentPlayer++;
            
            // Cas où la partie se termine
            if (GameBuilder.CURRENTGAME.NumberOfTurns == 0 ||
                GameBuilder.CURRENTGAME.Players.Count(p => p.Race.hasUnits()) == 1)
            {
                winner = GameBuilder.CURRENTGAME.getWinner();
            }          
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

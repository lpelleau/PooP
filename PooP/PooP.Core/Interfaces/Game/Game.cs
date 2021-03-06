﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Interfaces.Games
{
    /// <summary>
    /// Represents a game
    /// </summary>
    public interface Game
    {
        /// <summary>
        /// Gets the current playing player
        /// </summary>
        /// <returns>The player whose turn is on</returns>
        Player getCurrentPlayer();

        /// <summary>
        /// Computes the winner of the game
        /// </summary>
        /// <returns>The winning player</returns>
        Player getWinner();

        /// <summary>
        /// The name of the file in which the game is saved
        /// By default, it is null
        /// </summary>
        string OpenedFile
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the best moves
        /// </summary>
        /// <returns>Possible best moves</returns>
        int[] getBestMoves();
    }
}

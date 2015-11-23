﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PooP.Core.Interfaces.Games
{
    public interface Game
    {
        void endGame();

        Player getCurrentPlayer();

        Player getWinner();
    }
}
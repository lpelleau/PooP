using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PooP.Core.Implementation.Maps;
using PooP.Core.Interfaces;
using PooP.Core.Interfaces.Maps;

namespace PooP.Core.Implementation.Games
{
    /// <summary>
    /// Implements a demo game
    /// </summary>
    /// <see cref="GameBuilder"/>
    public class DemoGameBuilder : GameBuilder
    {
        /// <summary>
        /// A demo game has 5 turns
        /// </summary>
        /// <see cref="GameBuilder"/>
        public override int NbTurns
        {
            get {return 5;}
        }

        /// <summary>
        /// Creates the demo map
        /// </summary>
        /// <returns>The created demo map</returns>
        /// <see cref="GameBuilder"/>
        public override Map createMap()
        {
            Map map = new DemoMap().create();
            return map;
        }

        /// <summary>
        /// Creates the players
        /// </summary>
        /// <param name="players">An array with the players names as strings</param>
        /// <param name="races">An array with the players races as strings</param>
        /// <returns>An array with </returns>
        /// <see cref="GameBuilder"/>
        public override Player[] getPlayers(string[] players, string[] races)
        {
            List<Player> pl = new List<Player>();
            for (int i = 0; i < players.Count(); i++)
                pl.Add(new PlayerImpl(players[i], races[i]));
            return pl.ToArray();
        }
    }

    /// <summary>
    /// Implements a small game
    /// </summary>
    /// <see cref="GameBuilder"/>
    public class SmallGameBuilder : GameBuilder
    {
        /// <summary>
        /// A small game has 20 turns
        /// </summary>
        /// <see cref="GameBuilder"/>
        public override int NbTurns
        {
            get { return 20; }
        }

        /// <summary>
        /// Creates the small map
        /// </summary>
        /// <returns>The created small map</returns>
        /// <see cref="GameBuilder"/>
        public override Map createMap()
        {
            Map map = new SmallMap().create();
            return map;
        }

        /// <summary>
        /// Creates the players
        /// </summary>
        /// <param name="players">An array with the players names as strings</param>
        /// <param name="races">An array with the players races as strings</param>
        /// <returns>An array with </returns>
        /// <see cref="GameBuilder"/>
        public override Player[] getPlayers(string[] players, string[] races)
        {
            List<Player> pl = new List<Player>();
            for (int i = 0; i < players.Count(); i++)
                pl.Add(new PlayerImpl(players[i], races[i]));
            return pl.ToArray();
        }
    }

    /// <summary>
    /// Implements a standard game
    /// </summary>
    /// <see cref="GameBuilder"/>
    public class StandardGameBuilder : GameBuilder
    {
        /// <summary>
        /// A standard game has 30 turns
        /// </summary>
        /// <see cref="GameBuilder"/>
        public override int NbTurns
        {
            get { return 30; }
        }

        /// <summary>
        /// Creates the standard map
        /// </summary>
        /// <returns>The created standard map</returns>
        /// <see cref="GameBuilder"/>
        public override Map createMap()
        {
            Map map = new StandardMap().create();
            return map;
        }

        /// <summary>
        /// Creates the players
        /// </summary>
        /// <param name="players">An array with the players names as strings</param>
        /// <param name="races">An array with the players races as strings</param>
        /// <returns>An array with </returns>
        /// <see cref="GameBuilder"/>
        public override Player[] getPlayers(string[] players, string[] races)
        {
            List<Player> pl = new List<Player>();
            for (int i = 0; i < players.Count(); i++)
                pl.Add(new PlayerImpl(players[i], races[i]));
            return pl.ToArray();
        }
    }
}

using PooP.Core.Exceptions;
using PooP.Core.Implementation.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.Core.Implementation.Games
{
    /// <summary>
    /// Gets a game builder from a difficulty
    /// </summary>
    public class GameBuilderFactory
    {
        /// <summary>
        /// Gets the game builder according to a difficulty level
        /// </summary>
        /// <param name="difficulty">Difficulty level</param>
        /// <returns>The needed game builder</returns>
        public static GameBuilder get(string difficulty)
        {
            switch (difficulty.ToLower())
            {
                case "demo": return new DemoGameBuilder();
                case "small": return new SmallGameBuilder();
                case "standard": return new StandardGameBuilder();
                default: throw new NotExistingDifficultyException(difficulty);
            }
        }
    }
}

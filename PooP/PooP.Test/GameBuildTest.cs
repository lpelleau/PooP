using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Exceptions;

namespace PooP.Test
{
    /// <summary>
    /// Tests the game builders
    /// </summary>
    [TestClass]
    public class GameBuildTest
    {
        /// <summary>
        /// Tests the implementation with two equal races
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RaceException))]
        public void SameRaceTest()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "elf", "elf" };
            GameBuilderFactory.get("small").createGame(players, races);
        }

        /// <summary>
        /// Tries to create a demo game
        /// </summary>
        [TestMethod]
        public void DemoGameTest()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("demo").createGame(players, races);
            Assert.IsNotNull(GameBuilder.CURRENTGAME);
            Assert.IsTrue(GameBuilder.CURRENTGAME.NumberOfTurns == 5);
        }

        /// <summary>
        /// Tries to create a small game
        /// </summary>
        [TestMethod]
        public void SmallGameTest()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("small").createGame(players, races);
            Assert.IsNotNull(GameBuilder.CURRENTGAME);
            Assert.IsTrue(GameBuilder.CURRENTGAME.NumberOfTurns == 20);
        }

        /// <summary>
        /// Tries to create a standard game
        /// </summary>
        [TestMethod]
        public void StandardGameTest()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("standard").createGame(players, races);
            Assert.IsNotNull(GameBuilder.CURRENTGAME);
            Assert.IsTrue(GameBuilder.CURRENTGAME.NumberOfTurns == 30);
        }

        /// <summary>
        /// Tries to create a game with a wrong difficulty
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotExistingDifficultyException))]
        public void WrongDifficultyGameTest()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("incorrect").createGame(players, races);
        }
    }
}

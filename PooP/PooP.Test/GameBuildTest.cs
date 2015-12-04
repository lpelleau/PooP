using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Exceptions;
using PooP.Core.Interfaces;
using PooP.Core.Ressource;

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
            Assert.AreEqual(5, GameBuilder.CURRENTGAME.NumberOfTurns);
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
            Assert.AreEqual(20, GameBuilder.CURRENTGAME.NumberOfTurns);
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
            Assert.AreEqual(30, GameBuilder.CURRENTGAME.NumberOfTurns);
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

        /// <summary>
        /// Tests if all the units of a same race are grouped
        /// </summary>
        [TestMethod]
        public void GroupeRacesTest()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("standard").createGame(players, races);
            for (int i = 0; i < GameBuilder.CURRENTGAME.Players.Length ;i++ )
            {
                Player p = GameBuilder.CURRENTGAME.Players[i];
                Position pos = p.Race.Units[0].Position;
                Assert.IsTrue(p.Race.Units.TrueForAll(u => u.Position.Equals(pos)));
            }
        }
    }
}

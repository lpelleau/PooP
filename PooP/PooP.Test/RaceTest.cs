using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Races;
using PooP.Core.Interfaces.Races;
using PooP.Core.Exceptions;
using PooP.Core.Implementation.Games;

namespace PooP.Test
{
    /// <summary>
    /// Tests the race
    /// </summary>
    [TestClass]
    public class RaceTest
    {
        Race h, o, e;

        /// <summary>
        /// Sets the test environment
        /// </summary>
        [TestInitialize]
        public void init()
        {
            h = RaceFactoryImpl.getRace("Human");
            o = RaceFactoryImpl.getRace("Orc");
            e = RaceFactoryImpl.getRace("Elf");
        }

        /// <summary>
        /// Tests if a created race has 0 unit
        /// </summary>
        [TestMethod]
        public void TestEmptyUnits()
        {
            Assert.IsTrue(h.Units.Count == 0);
        }

        /// <summary>
        /// Tests the constants for the races
        /// </summary>
        [TestMethod]
        public void TestConstants()
        {
            // Test the human constants
            Assert.IsTrue(h.Attack == 6);
            Assert.IsTrue(h.AttackDistance == 1);
            Assert.IsTrue(h.Defence == 3);
            Assert.IsTrue(h.Life == 15);
            Assert.IsTrue(h.MoveDistance == 2);

            // Test the orc constants
            Assert.IsTrue(o.Attack == 5);
            Assert.IsTrue(o.AttackDistance == 1);
            Assert.IsTrue(o.Defence == 2);
            Assert.IsTrue(o.Life == 17);
            Assert.IsTrue(o.MoveDistance == 2);

            // Test the elf constants
            Assert.IsTrue(e.Attack == 4);
            Assert.IsTrue(e.AttackDistance == 2);
            Assert.IsTrue(e.Defence == 3);
            Assert.IsTrue(e.Life == 12);
            Assert.IsTrue(e.MoveDistance == 2);
        }

        /// <summary>
        /// Tests the creation of a bad race
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RaceException))]
        public void TestBadRace()
        {
            Race r = RaceFactoryImpl.getRace("UndefinedRace");
        }

        /// <summary>
        /// Checks the victory points according to race and tile type
        /// </summary>
        [TestMethod]
        public void VictoryPointsTest()
        {
            // Load the game in tester1
            // First player has orcs
            // Second has elves
            GameSave.INSTANCE.load("../../Test_files/tester1");
           
            // An orc on a plain tile -> 1pt
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getVictoryPoints() == 1);
            // An orc on a mountain tile -> 2pts
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[2].getVictoryPoints() == 2);
            // An orc on a forest tile -> 1pt
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[3].getVictoryPoints() == 1);

            // An elf on a plain tile -> 1pt
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[0].getVictoryPoints() == 1);
            // An elf on a mountain tile -> 0pt
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[1].getVictoryPoints() == 0);
            // An elf on a forest tile -> 3pts
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[1].Race.Units[4].getVictoryPoints() == 3);

            // Load the game in tester2
            // First player has human
            // Second has elves
            GameSave.INSTANCE.load("../../Test_files/tester2");

            // A human on a water tile -> 0pts
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[4].getVictoryPoints() == 0);
            // A human on a plain tile -> 2pts
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getVictoryPoints() == 2);
            // A human on a mountain tile -> 1pt
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[0].getVictoryPoints() == 1);
            // A human on a forest tile -> 1pt
            Assert.IsTrue(GameBuilder.CURRENTGAME.Players[0].Race.Units[3].getVictoryPoints() == 1);
        }
    }
}

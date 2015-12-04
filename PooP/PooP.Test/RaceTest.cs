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
            Assert.AreEqual(0, h.Units.Count);
        }

        /// <summary>
        /// Tests the constants for the races
        /// </summary>
        [TestMethod]
        public void TestConstants()
        {
            // Test the human constants
            Assert.AreEqual(6,  h.Attack);
            Assert.AreEqual(1,  h.AttackDistance);
            Assert.AreEqual(3,  h.Defence);
            Assert.AreEqual(15, h.Life);
            Assert.AreEqual(2,  h.MoveDistance);

            // Test the orc constants
            Assert.AreEqual(5,  o.Attack);
            Assert.AreEqual(1,  o.AttackDistance);
            Assert.AreEqual(2,  o.Defence);
            Assert.AreEqual(17, o.Life);
            Assert.AreEqual(2,  o.MoveDistance);

            // Test the elf constants
            Assert.AreEqual(4,  e.Attack);
            Assert.AreEqual(2,  e.AttackDistance);
            Assert.AreEqual(3,  e.Defence);
            Assert.AreEqual(12, e.Life);
            Assert.AreEqual(2,  e.MoveDistance);
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
            Assert.AreEqual(1, GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getVictoryPoints());
            // An orc on a mountain tile -> 2pts
            Assert.AreEqual(2, GameBuilder.CURRENTGAME.Players[0].Race.Units[2].getVictoryPoints());
            // An orc on a forest tile -> 1pt
            Assert.AreEqual(1, GameBuilder.CURRENTGAME.Players[0].Race.Units[3].getVictoryPoints());

            // An elf on a plain tile -> 1pt
            Assert.AreEqual(1, GameBuilder.CURRENTGAME.Players[1].Race.Units[0].getVictoryPoints());
            // An elf on a mountain tile -> 0pt
            Assert.AreEqual(0, GameBuilder.CURRENTGAME.Players[1].Race.Units[1].getVictoryPoints());
            // An elf on a forest tile -> 3pts
            Assert.AreEqual(3, GameBuilder.CURRENTGAME.Players[1].Race.Units[4].getVictoryPoints());

            // Load the game in tester2
            // First player has human
            // Second has elves
            GameSave.INSTANCE.load("../../Test_files/tester2");

            // A human on a water tile -> 0pts
            Assert.AreEqual(0, GameBuilder.CURRENTGAME.Players[0].Race.Units[4].getVictoryPoints());
            // A human on a plain tile -> 2pts
            Assert.AreEqual(2, GameBuilder.CURRENTGAME.Players[0].Race.Units[1].getVictoryPoints());
            // A human on a mountain tile -> 1pt
            Assert.AreEqual(1, GameBuilder.CURRENTGAME.Players[0].Race.Units[0].getVictoryPoints());
            // A human on a forest tile -> 1pt
            Assert.AreEqual(1, GameBuilder.CURRENTGAME.Players[0].Race.Units[3].getVictoryPoints());
        }
    }
}

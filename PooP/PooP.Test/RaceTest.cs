using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Races;
using PooP.Core.Interfaces.Races;
using PooP.Core.Exceptions;

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
            Assert.IsTrue(h.MoveDistance == 1);

            // Test the orc constants
            Assert.IsTrue(o.Attack == 5);
            Assert.IsTrue(o.AttackDistance == 2);
            Assert.IsTrue(o.Defence == 2);
            Assert.IsTrue(o.Life == 17);
            Assert.IsTrue(o.MoveDistance == 1);

            // Test the elf constants
            Assert.IsTrue(e.Attack == 4);
            Assert.IsTrue(e.AttackDistance == 2);
            Assert.IsTrue(e.Defence == 3);
            Assert.IsTrue(e.Life == 12);
            Assert.IsTrue(e.MoveDistance == 1);
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
    }
}

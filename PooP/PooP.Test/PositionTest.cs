﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;

namespace PooP.Test
{
    /// <summary>
    /// Tests the position
    /// </summary>
    [TestClass]
    public class PositionTest
    {
        Position p;

        /// <summary>
        /// Sets the environment for the tests
        /// </summary>
        [TestInitialize]
        public void init()
        {
            p = new Position(1, 5);
        }

        /// <summary>
        /// Tests the constructor and the getter
        /// </summary>
        [TestMethod]
        public void PositionConstructorGetTest()
        { 
            Assert.IsTrue(p.XPosition == 1 && p.YPosition == 5);
        }

        /// <summary>
        /// Tests the setter with a valid position
        /// </summary>
        [TestMethod]
        public void PositionSetValidTest()
        {
            p.XPosition = 9;
            p.YPosition = 456;
            Assert.IsTrue(p.XPosition == 9 && p.YPosition == 456);
        }

        /// <summary>
        /// Tests the setter with an invalid position
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BadPositionException))]
        public void SetInvalidTest()
        {
            p.XPosition = -1;
        }
    }
}
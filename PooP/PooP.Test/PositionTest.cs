using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual(1, p.XPosition);
            Assert.AreEqual(5, p.YPosition);
        }

        /// <summary>
        /// Tests the setter with a valid position
        /// </summary>
        [TestMethod]
        public void PositionSetValidTest()
        {
            p.XPosition = 9;
            p.YPosition = 456;
            Assert.AreEqual(9, p.XPosition);
            Assert.AreEqual(456, p.YPosition);
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

        /// <summary>
        /// Tests the method equals
        /// </summary>
        [TestMethod]
        public void EqualityTest()
        {
            Position p2 = new Position(1, 5);
            Position p3 = new Position(2, 5);
            Position p4 = new Position(1, 4);
            Position p5 = new Position(2, 4);

            Assert.AreEqual(p, p2);
            Assert.AreNotEqual(p, p3);
            Assert.AreNotEqual(p, p4);
            Assert.AreNotEqual(p, p5);
        }
    }
}

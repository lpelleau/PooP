using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;

namespace Test
{
    [TestClass]
    public class PositionTest
    {
        Position p;
        [TestInitialize]
        public void init()
        {
            p = new Position(1, 5);
        }
        [TestMethod]
        public void ConstructorGetTest()
        { 
            Assert.IsTrue(p.XPosition == 1 && p.YPosition == 5);
        }

        [TestMethod]
        public void SetValidTest()
        {
            p.XPosition = 9;
            p.YPosition = 456;
            Assert.IsTrue(p.XPosition == 9 && p.YPosition == 456);
        }

        [TestMethod]
        [ExpectedException(typeof(BadPositionException), "Position out of bounds !")]
        public void SetInvalidTest()
        {
            p.XPosition = -1;
        }
    }
}

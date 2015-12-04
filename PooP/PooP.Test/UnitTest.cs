using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using PooP.Core.Implementation.Races;
using PooP.Core.Interfaces.Races;
using PooP.Core.Implementation;
using PooP.Core.Interfaces;

namespace PooP.Test
{
    /// <summary>
    /// Tests the unit
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        Race r;
        Position p;
        Unit u;

        /// <summary>
        /// Inits the test environment
        /// </summary>
        [TestInitialize]
        public void init()
        {
            r = RaceFactoryImpl.getRace("Human");
            p = new Position(2, 5);
            u = new UnitImpl(r, p);
        }

        /// <summary>
        /// Tests the constructor and the getter
        /// </summary>
        [TestMethod]
        public void UnitConstructorGetTest()
        {
            Assert.AreEqual(0, u.MovePoints);
            Assert.AreEqual(r.Life, u.LifePoints);
            Assert.AreEqual(p, u.Position);
        }
    }
}

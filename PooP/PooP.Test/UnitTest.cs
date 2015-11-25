using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using PooP.Core.Implementation.Races;
using PooP.Core.Interfaces.Races;
using PooP.Core.Implementation;
using PooP.Core.Interfaces;

namespace PooP.Test
{
    [TestClass]
    public class UnitTest
    {
        Race r;
        Position p;
        Unit u;
        [TestInitialize]
        public void init()
        {
            r = RaceFactoryImpl.getRace("Human");
            p = new Position(2, 5);
            u = new UnitImpl(r, p);
        }
        [TestMethod]
        public void ConstructorGetTest()
        {
            Assert.IsTrue(u.MovePoints == 0);
            Assert.IsTrue(u.LifePoints == r.Life);
            Assert.IsTrue(u.Position == p);
        }
    }
}

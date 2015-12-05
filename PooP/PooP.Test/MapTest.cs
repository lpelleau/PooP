using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Implementation.Games;
using PooP.Core.Ressource;

namespace PooP.Test
{
    [TestClass]
    public class MapTest
    {
        /// <summary>
        /// Checks the given tiles for positions
        /// </summary>
        [TestMethod]
        public void TestGetTileAt()
        {
            GameSave.INSTANCE.load("../../Test_files/tester1");

            Assert.AreEqual("Water", GameBuilder.CURRENTGAME.Map.getTileAt(new Position(0, 0)).GetType().Name);
            Assert.AreEqual("Forest", GameBuilder.CURRENTGAME.Map.getTileAt(new Position(0, 1)).GetType().Name);
            Assert.AreEqual("Mountain", GameBuilder.CURRENTGAME.Map.getTileAt(new Position(1, 0)).GetType().Name);
            Assert.AreEqual("Plain", GameBuilder.CURRENTGAME.Map.getTileAt(new Position(2, 0)).GetType().Name);
        }
    }
}

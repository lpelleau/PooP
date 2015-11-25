using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using PooP.Core.Interfaces.Games;
using PooP.Core.Implementation.Games;

namespace PooP.Test
{
    [TestClass]
    public class ExportTest
    {
        Game g;

        [TestInitialize]
        public void init()
        {
            g = GameImpl.CURRENTGAME;
            // Init game
        }

        [TestMethod]
        public void ExportDataTest()
        {
            GameSave.INSTANCE.save("test", g);
        }
    }
}

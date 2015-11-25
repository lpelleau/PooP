using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using PooP.Core.Interfaces.Games;
using PooP.Core.Implementation.Games;

namespace Test
{
    [TestClass]
    public class ExportTest
    {
        [TestInitialize]
        public void init()
        {
        }

        [TestMethod]
        public void ExportDataTest()
        {
            GameSave.save("test", GameImpl.CURRENTGAME);
        }
    }
}

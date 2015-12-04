using Microsoft.VisualStudio.TestTools.UnitTesting;
using PooP.Core.Ressource;
using PooP.Core.Exceptions;
using PooP.Core.Interfaces.Games;
using PooP.Core.Implementation.Games;

namespace PooP.Test
{
    /// <summary>
    /// Tests the export
    /// </summary>
    [TestClass]
    public class ExportTest
    {
        /// <summary>
        /// Test the save
        /// </summary>
        [TestMethod]
        public void ExportDataTest()
        {
            string[] players = new string[2] { "Pl1", "Pl2" };
            string[] races = new string[2] { "orc", "elf" };
            GameBuilderFactory.get("standard").createGame(players, races);
            GameSave.INSTANCE.save("test");
        }

        /// <summary>
        /// Test the load
        /// </summary>
        [TestMethod]
        public void ImportDataTest()
        {
            GameSave.INSTANCE.load("test");
            GameSave.INSTANCE.save("test2");

            Assert.AreEqual(System.IO.File.ReadAllText("test.flav"), System.IO.File.ReadAllText("test2.flav"));
        }
    }
}


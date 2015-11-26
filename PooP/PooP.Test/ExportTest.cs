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
        [TestInitialize]
        public void init()
        {
            string[] players = new string[2] { "Pl1", "Pl2"};
            string[] races = new string[2] { "orc", "elf" };
            new SmallGameBuilder().createGame(players,races);
        }

        [TestMethod]
        public void ExportDataTest()
        {
            GameSave.INSTANCE.save("test", GameBuilder.CURRENTGAME);
        }
    }
}


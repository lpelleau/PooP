using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PooP.Core.Interfaces.Games;
using PooP.Core.Data.Games;

namespace PooP.Core.Implementation.Games
{
    public class GameSave
    {
        private static string EXTENSION = ".flav";
        public static void save(string SaveFile, Game RunningGame)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, GameImpl.CURRENTGAME.ToData());
            }
        }
        public static Game load(string SaveFile, Game RunningGame)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                return new GameImpl((GameData) formatter.Deserialize(stream));
            }
        }
    }
}

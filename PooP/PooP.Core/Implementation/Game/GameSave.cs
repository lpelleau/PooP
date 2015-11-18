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
        public void save(string SaveFile, Games RunningGame)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, new GameData());
            }
        }
        public void load(string SaveFile, Games RunningGame)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                //mo = (GameData) formatter.Deserialize(stream);
            }
        }
    }
}

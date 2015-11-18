using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PooP.Core
{
    public class GameSave
    {
        private static string EXTENSION = ".flav";
        public void save(string SaveFile, Game RunningGame)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, new GameData());
            }
        }
        public void load(string SaveFile, Game RunningGame)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                //mo = (GameData) formatter.Deserialize(stream);
            }
        }
    }
}

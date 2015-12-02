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
    /// <summary>
    /// Saves a game
    /// </summary>
    public class GameSave
    {
        // Defines the extension and creates a glabal instance
        private static string EXTENSION = ".flav";
        public static GameSave INSTANCE = new GameSave();

        /// <summary>
        /// Empty constructor
        /// </summary>
        private GameSave()
        {
        }

        /// <summary>
        /// Saves the game with an XML-like format
        /// </summary>
        /// <param name="SaveFile">Name of the file to write</param>
        public void save(string SaveFile)
        {
            // If the file name contains the extension, delete it
            if (SaveFile.LastIndexOf(EXTENSION) != -1)
                SaveFile = SaveFile.Substring(0, SaveFile.LastIndexOf(EXTENSION));
            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, GameBuilder.CURRENTGAME.ToData());
            }
        }

        /// <summary>
        /// Reads a file
        /// </summary>
        /// <param name="SaveFile">File to read</param>
        /// <returns>The created game</returns>
        public void load(string SaveFile)
        {
            // If the file name contains the extension, delete it
            if (SaveFile.LastIndexOf(EXTENSION) != -1)
                SaveFile = SaveFile.Substring(0, SaveFile.LastIndexOf(EXTENSION));

            XmlSerializer formatter = new XmlSerializer(typeof(GameData));
            using (Stream stream = new FileStream(SaveFile + EXTENSION, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                GameBuilder.createGame((GameData) formatter.Deserialize(stream));
            }
        }
    }
}

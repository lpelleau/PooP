using Microsoft.Win32;
using PooP.Core.Implementation.Games;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooP.GUI.Views.LoadGame
{
    public class SaveChoser
    {
        public static SaveChoser INSTANCE = new SaveChoser();

        private string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SmallWorld\\";
        private List<string> files;

        private SaveChoser()
        {

        }

        public void Refresh()
        {
            try
            {
                files = new List<string>(Directory.EnumerateFiles(PATH));
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(PATH);
                Refresh();
            }
        }

        public List<string> getSaves()
        {
            Refresh();
            return files.Where(f => f.Contains(GameSave.EXTENSION)).ToList<string>()
                .ConvertAll(f => f.Substring(f.LastIndexOf("\\") + 1))
                .ConvertAll(f => f.Substring(0, f.Count() - 5));
        }

        public void ImportSave(string file)
        {
            GameSave.INSTANCE.load(PATH + file + GameSave.EXTENSION);
        }

        public void SaveGame(string file)
        {
            //File.Create(PATH + "\\lsdflsdfk" + GameSave.EXTENSION);   
            try
            {
                GameSave.INSTANCE.save(PATH + file + GameSave.EXTENSION);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(PATH);
                SaveGame(file);
            }
        }

        public void DeleteGame(string file)
        {
            File.Delete(PATH + file + GameSave.EXTENSION);   
        }
    }
}

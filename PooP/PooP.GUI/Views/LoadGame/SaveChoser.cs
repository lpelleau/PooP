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
        private string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SmallWorld";
        private List<string> files;

        public void Refresh()
        {
            try
            {
                files = new List<string>(Directory.EnumerateDirectories(PATH));
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory(PATH);
                Refresh();
            }
        }

        public List<string> getSaves()
        {
            Refresh();
            return files.Where(f => f.Contains(GameSave.EXTENSION)).ToList<string>();
        }

        public void ImportSave(string file)
        {
            GameSave.INSTANCE.load(PATH + "\\" + file + GameSave.EXTENSION);
        }

        public void SaveGame(string file)
        {
            //File.Create(PATH + "\\lsdflsdfk" + GameSave.EXTENSION);   
            GameSave.INSTANCE.save(PATH + "\\" + file + GameSave.EXTENSION);
        }
    }
}

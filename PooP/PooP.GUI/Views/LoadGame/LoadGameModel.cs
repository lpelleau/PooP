using PooP.GUI.Audio;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PooP.GUI.Views.LoadGame
{
    public class LoadGameModel
    {
        private WindowInterface window;
        private LoadGameInterface page;

        public LoadGameModel(WindowInterface window, LoadGameInterface page)
        {
            this.window = window;
            this.page = page;
        }

        public ICommand Refresh
        {
            get
            {
                return new RefreshCommand(page);
            }
        }

        public ICommand Delete
        {
            get
            {
                return new DeleteCommand(page);
            }
        }

        public ICommand Load
        {
            get
            {
                return new LoadGameCommand(window, page);
            }
        }

        public ICommand Back
        {
            get
            {
                return new BackCommand(window);
            }
        }

        public ICommand Sound
        {
            get
            {
                return SoundCommand.INSTANCE;
            }
        }
    }
}

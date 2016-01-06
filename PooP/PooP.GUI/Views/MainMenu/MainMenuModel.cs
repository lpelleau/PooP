using PooP.GUI.Audio;
using PooP.GUI.Ressources;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PooP.GUI.Views.MainMenu
{
    public class MainMenuModel
    {
        public WindowInterface window;
        public Page page;

        public MainMenuModel(WindowInterface window, Page page)
        {
            this.window = window;
            this.page = page;
        }

        public ICommand Credits
        {
            get
            {
                return new CreditsCommand(window);
            }
        }

        public ICommand LoadGame
        {
            get
            {
                return new LoadGameCommand(window);
            }
        }

        public ICommand NewGame
        {
            get
            {
                return new NewGameCommand(window);
            }
        }

        public ICommand Tutorial
        {
            get
            {
                return new TutorialCommand(window);
            }
        }

        public ICommand AskQuit
        {
            get
            {
                return new AskQuitCommand(page);
            }
        }

        public ICommand AbortQuit
        {
            get
            {
                return new AbortQuitCommand(page);
            }
        }

        public ICommand Quit
        {
            get
            {
                return new QuitCommand(window);
            }
        }

        public ICommand FullScreen
        {
            get
            {
                return new FullScreenCommand(window, page);
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

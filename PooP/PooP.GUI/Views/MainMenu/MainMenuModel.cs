﻿using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PooP.GUI.Views.MainMenu
{
    public class MainMenuModel
    {
        public WindowInterface window;

        public MainMenuModel(WindowInterface window)
        {
            this.window = window;
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

        public ICommand Quit
        {
            get
            {
                return new QuitCommand(window);
            }
        }
    }
}

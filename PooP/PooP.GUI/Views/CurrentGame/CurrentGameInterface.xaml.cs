﻿using PooP.Core.Implementation.Commands;
using PooP.Core.Implementation.Games;
using PooP.GUI.Audio;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PooP.GUI.Views.CurrentGame
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CurrentGameInterface : Page, PageInterface
    {
        private WindowInterface window;
        public CurrentGameInterface(WindowInterface window)
        {
            InitializeComponent();
            this.window = window;
            DataContext = new CurrentGameModel(window, this);
            OnReload();
        }

        public void OnReload()
        {
            if (Sound.INSTANCE.isOn())
            {
                ((Image)FindName("MusicOFF")).Visibility = Visibility.Hidden;
            }
            else
            {
                ((Image)FindName("MusicOFF")).Visibility = Visibility.Visible;
            }

            if (UndoableImpl.DoneCommands.Count == 0)
            {
                ((Image)FindName("UndoStyle")).Source = new BitmapImage(new Uri("../../images/pages/undo.png", UriKind.Relative));
            }
            else
            {
                ((Image)FindName("UndoStyle")).Source = new BitmapImage(new Uri("../../images/pages/undoEnable.png", UriKind.Relative));
            }

            if (UndoableImpl.UndoneCommands.Count == 0)
            {
                ((Image)FindName("RedoStyle")).Source = new BitmapImage(new Uri("../../images/pages/redo.png", UriKind.Relative));
            }
            else
            {
                ((Image)FindName("RedoStyle")).Source = new BitmapImage(new Uri("../../images/pages/redoEnable.png", UriKind.Relative));
            }
        }
    }
}

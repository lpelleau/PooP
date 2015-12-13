using PooP.GUI.Audio;
using PooP.GUI.Views.Credits;
using PooP.GUI.Views.CurrentGame;
using PooP.GUI.Views.MainMenu;
using PooP.GUI.Views.NewGame;
using PooP.GUI.Views.Tutorial;
using System;
using System.Collections.Generic;
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

namespace PooP.GUI.Views.WindowApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowInterface : Window
    {
        private Page mainMenu;
        private Page tutorial;
        private Page credits;
        private Stack<Page> flow;

        public WindowInterface()
        {
            InitializeComponent();

            flow = new Stack<Page>();

            mainMenu = new MainMenuInterface(this);
            tutorial = new TutorialInterface(this);
            credits = new CreditsInterface(this);

            OpenMainMenu();

            Sound.INSTANCE.StartMusic();
        }

        public void OpenCredits()
        {
            frame.Content = credits;

            flow.Push(credits);
        }

        public void OpenCurrentGame()
        {
            CurrentGameInterface page = new CurrentGameInterface(this);
            frame.Content = page;

            flow.Push(page);
        }

        public void OpenMainMenu()
        {
            frame.Content = mainMenu;

            flow.Push(mainMenu);
        }

        public void OpenNewGame()
        {
            NewGameInterface page = new NewGameInterface(this);
            frame.Content = page;

            flow.Push(page);
        }

        public void OpenTutorial()
        {
            frame.Content = tutorial;

            flow.Push(tutorial);
        }

        public void CloseCurrent()
        {
            flow.Pop();

            if (flow.Count == 0)
            {
                Sound.INSTANCE.StopMusic();
                this.Close();
                return;
            }

            frame.Content = flow.Peek();
        }
    }
}

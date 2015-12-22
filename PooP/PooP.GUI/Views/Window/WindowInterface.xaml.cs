using PooP.GUI.Audio;
using PooP.GUI.Views.Credits;
using PooP.GUI.Views.CurrentGame;
using PooP.GUI.Views.FinishedGame;
using PooP.GUI.Views.LoadGame;
using PooP.GUI.Views.MainMenu;
using PooP.GUI.Views.NewGame;
using PooP.GUI.Views.SplashScreen;
using PooP.GUI.Views.Tutorial;
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
using System.Windows.Forms;
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
        private double originH;
        private double originW;

        private bool isfullScreen;

        public bool IsfullScreen()
        {
            return isfullScreen;
        }

        private Page splashScreen;
        private Page mainMenu;
        private Page tutorial;
        private Page credits;
        private Stack<Page> flow;

        public WindowInterface()
        {
            InitializeComponent();

            FullScreen();

            flow = new Stack<Page>();

            splashScreen = new SplashScreenInterface(this);
            mainMenu = new MainMenuInterface(this);
            tutorial = new TutorialInterface(this);
            credits = new CreditsInterface(this);

            OpenSplashScreen();

            Sound.INSTANCE.StartMusic();

            Closing += OnWindowClosing;
        }

        public void FullScreen()
        {
            System.Drawing.Rectangle resolution = Screen.PrimaryScreen.Bounds;

            Window window = (Window)FindName("Window");
            Frame frame = (Frame)FindName("frame");

            originH = frame.Height;
            originW = frame.Width;

            double stH = resolution.Height / originH;
            double stW = resolution.Width / originW;
            if (stH < stW)
            {
                stW = stH;
            }
            else
            {
                stH = stW;
            }
            frame.Height = resolution.Height;
            frame.Width = resolution.Width;

            frame.RenderTransformOrigin = new Point(0.5, 0.5);
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new ScaleTransform(stW, stH));
            frame.RenderTransform = tg;

            window.WindowState = WindowState.Maximized;
            window.Topmost = true;
            window.Style = null;

            isfullScreen = true;
        }

        public void SmallScreen()
        {
            Window window = (Window)FindName("Window");
            Frame frame = (Frame)FindName("frame");

            frame.Height = originH;
            frame.Width = originW;

            frame.RenderTransform = null;

            window.WindowState = WindowState.Normal;
            window.Topmost = true;
            window.Style = null;
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            isfullScreen = false;
        }

        public void OpenSplashScreen()
        {
            frame.Content = splashScreen;

            flow.Push(splashScreen);
        }

        public void OpenCredits()
        {
            frame.Content = credits;
            ((PageInterface)credits).OnReload();
            flow.Push(credits);
        }

        public void OpenCurrentGame()
        {
            if (flow.Peek() is LoadGameInterface || flow.Peek() is NewGameInterface)
            {
                flow.Pop();

                Page page = new CurrentGameInterface(this);
                frame.Content = page;

                flow.Push(page);
            }
        }

        public void CurrentToFinishedGame()
        {
            if (flow.Peek() is CurrentGameInterface)
            {
                flow.Pop();

                Page page = new FinishedGameInterface(this);
                frame.Content = page;

                flow.Push(page);
            }
        }

        public void OpenMainMenu()
        {
            if (flow.Peek() is SplashScreenInterface)
            {
                flow.Pop();

                frame.Content = mainMenu;
                ((PageInterface)mainMenu).OnReload();
                flow.Push(mainMenu);
            }
        }

        public void OpenLoadGame()
        {
            Page page = new LoadGameInterface(this);
            frame.Content = page;

            flow.Push(page);
        }

        public void OpenNewGame()
        {
            Page page = new NewGameInterface(this);
            frame.Content = page;

            flow.Push(page);
        }

        public void OpenTutorial()
        {
            frame.Content = tutorial;
            ((PageInterface)tutorial).OnReload();
            flow.Push(tutorial);
        }

        public void CloseCurrent()
        {
            flow.Pop();

            if (flow.Count == 0)
            {
                OnWindowClosing(null, null);
                this.Close();
            }
            else
            {
                frame.Content = flow.Peek();
                ((PageInterface)flow.Peek()).OnReload();
            }
        }

        private void OnWindowClosing(object sender, CancelEventArgs e) 
        {
            Sound.INSTANCE.StopMusic();
        }
    }
}

using PooP.GUI.Views.WindowApp;
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

namespace PooP.GUI.Views.Tutorial
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TutorialInterface : Page
    {
        private WindowInterface window;
        private List<Canvas> tips;

        public TutorialInterface(WindowInterface window)
        {
            InitializeComponent();
            this.window = window;

            DataContext = new TutorialModel(window, this);

            tips = new List<Canvas>();
            tips.Add((Canvas)FindName("tipN0"));
            tips.Add((Canvas)FindName("tipN1"));
        }

        public List<Canvas> getTips()
        {
            return tips;
        }
    }
}

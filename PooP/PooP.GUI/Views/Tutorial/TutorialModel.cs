using PooP.GUI.Audio;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PooP.GUI.Views.Tutorial
{
    public class TutorialModel
    {
        public WindowInterface window;
        public TutorialInterface page;

        public TutorialModel(WindowInterface window, TutorialInterface page)
        {
            this.window = window;
            this.page = page;
        }

        public ICommand NextTips
        {
            get
            {
                return new NextTipsCommand(page);
            }
        }

        public ICommand PreviousTips
        {
            get
            {
                return new PreviousTipsCommand(page);
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

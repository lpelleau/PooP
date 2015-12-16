using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PooP.GUI.Views.Tutorial
{
    public class PreviousTipsCommand : TipsCommand
    {
        public PreviousTipsCommand(TutorialInterface page)
            : base(page)
        {

        }

        public override void Execute(Object o)
        {
            if (currentTip > 0)
            {
                page.getTips()[currentTip].Visibility = Visibility.Collapsed;
                currentTip--;
                page.getTips()[currentTip].Visibility = Visibility.Visible;
            }
        }
    }
}

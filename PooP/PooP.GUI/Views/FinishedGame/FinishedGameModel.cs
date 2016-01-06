using PooP.Core.Implementation.Games;
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

namespace PooP.GUI.Views.FinishedGame
{
    public class FinishedGameModel
    {
        private WindowInterface window;
        private FinishedGameInterface page;

        public FinishedGameModel(WindowInterface window, FinishedGameInterface page)
        {
            this.window = window;
            this.page = page;

            ((Label)page.FindName("Winner")).Content = "The winner is \"" + GameBuilder.CURRENTGAME.getWinner().Name + "\"";

            ((Label)page.FindName("P1Stats")).Content = GameBuilder.CURRENTGAME.Players[0].Name + ((Label)page.FindName("P1Stats")).Content;
            ((Label)page.FindName("R1")).Content += GameBuilder.CURRENTGAME.Players[0].Race.ToString();
            ((Label)page.FindName("VP1")).Content += GameBuilder.CURRENTGAME.Players[0].Race.getVictoryPoints().ToString();
            ((Label)page.FindName("UL1")).Content += GameBuilder.CURRENTGAME.Players[0].Race.Units.Count().ToString();

            ((Label)page.FindName("P2Stats")).Content = GameBuilder.CURRENTGAME.Players[1].Name + ((Label)page.FindName("P2Stats")).Content;
            ((Label)page.FindName("R2")).Content += GameBuilder.CURRENTGAME.Players[1].Race.ToString();
            ((Label)page.FindName("VP2")).Content += GameBuilder.CURRENTGAME.Players[1].Race.getVictoryPoints().ToString();
            ((Label)page.FindName("UL2")).Content += GameBuilder.CURRENTGAME.Players[1].Race.Units.Count().ToString();
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

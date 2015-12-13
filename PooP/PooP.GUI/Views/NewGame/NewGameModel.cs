using PooP.Core.Implementation.Games;
using PooP.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PooP.GUI.Views.NewGame
{
    /// <summary>
    /// ViewModel of the initialization window
    /// </summary>
    public class NewGameModel
    {
        public const string IMAGES_PATH = "/SmallWorld;component/images/";

        /// <summary>
        /// Constructor
        /// Puts an empty string in all the values for game instanciation
        /// </summary>
        public NewGameModel()
        {
            Player1Name = "";
            Player2Name = "";
            Player1Race = "";
            Player2Race = "";
            MapSize = "";
        }

        // The launch command
        public ICommand Launch
        {
            get
            {
                return new LaunchCommand(this);
            }
        }

        // Command for a change in P1's race
        public ICommand ChangeRace1
        {
            get
            {
                return new ChangeRace1Command(this);
            }
        }

        // Command for a change in P2's race
        public ICommand ChangeRace2
        {
            get
            {
                return new ChangeRace2Command(this);
            }
        }

        // Command for a change in the map size
        public ICommand ChangeMapSize
        {
            get
            {
                return new ChangeMapSizeCommand(this);
            }
        }

        // Command to quit
        public ICommand Quit
        {
            get
            {
                return new QuitCommand(this);
            }
        }

        // Values for game creation

        public string Player1Name
        {
            get;
            set;
        }

        public string Player2Name
        {
            get;
            set;
        }

        public string Player1Race
        {
            get;
            set;
        }

        public string Player1RaceImage
        {
            get
            {
                return IMAGES_PATH + Player1Race.ToLower() + ".png";
            }
        }

        public string Player1RaceFont
        {
            get
            {
                switch (Player1Race)
                {            // ENGRAVERS, LUCIDA CALLIG, Copperplate Gothic Light
                    case "Elf": return "Lucida Calligraphy";
                    case "Human" : return "Engravers MT";
                    case "Orc": return "Copperplate Gothic Light";
                    default: return "Segoe US";
                }
            }
        }

        public string Player2Race
        {
            get;
            set;
        }

        public string Player2RaceImage
        {
            get
            {
                return IMAGES_PATH + Player2Race.ToLower() + ".png";
            }
        }

        public string Player2RaceFont
        {
            get
            {
                switch (Player2Race)
                {            // ENGRAVERS, LUCIDA CALLIG, Copperplate Gothic Light
                    case "Elf": return "Lucida Calligraphy";
                    case "Human": return "Engravers MT";
                    case "Orc": return "Copperplate Gothic Light";
                    default: return "Segoe US";
                }
            }
        }


        public string MapSize
        {
            get;
            set;
        }
    }
}

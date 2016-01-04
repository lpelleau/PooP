using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PooP.Core.Interfaces.Maps;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Interactivity;
using PooP.Core.Ressource;

namespace PooP.GUI.Views.CurrentGame
{
    public class CurrentGameModel
    {
        public WindowInterface window;
        public CurrentGameInterface page;

        private static string TILES_PATH = "../../images/tileset/";
        private static string TILES_EXT = ".bmp";
        private static string UNITS_PATH = "../../images/races/";
        private static string UNITS_EXT = ".png";

        public Grid map;
        public Border bo;
        public Border unitBo;
        public Border[] helpBo;

        public bool HelpOn = false;

        private string GetTileIndexFromAround(string tileType, string[,] around){
            // All around are non-forest tiles
            if (                          around[0, 1] != tileType
                && around[1, 0] != tileType                           && around[1, 2] != tileType
                                            && around[2, 1] != tileType)
            {
                return "13";
            }
            // Left-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType                           && around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "12";
            }
            // Right-up is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "35";
            }
            // Left, right and up are non-forest
            else if (                           around[0, 1] != tileType
                    && around[1, 0] != tileType                           && around[1, 2] != tileType
                    &&                           around[2, 1] == tileType)
            {
                return "11";
            }
            // Left-down is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType                           && around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "10";
            }
            // Right-down is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "36";
            }
            // Left is non-forest
            else if (                          around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] != tileType                           && around[1, 2] == tileType
                    &&                           around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "09";
            }
            // Right is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType
                    && around[1, 0] == tileType                           && around[1, 2] != tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType)
            {
                return "15";
            }
            // Up is non-forest
            else if (                            around[0, 1] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "20";
            }
            // Down is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType                           && around[1, 2] == tileType
                    &&                           around[2, 1] != tileType)
            {
                return "21";
            }
            // Up & down is non-forest
            else if (                            around[0, 1] != tileType
                    && around[1, 0] == tileType &&                          around[1, 2] == tileType
                                                && around[2, 1] != tileType)
            {
                return "22";
            }
            // Up & down & left is non-forest
            else if (                            around[0, 1] != tileType
                    && around[1, 0] != tileType &&                          around[1, 2] == tileType
                                                && around[2, 1] != tileType)
            {
                return "23";
            }
            // Up & down & right is non-forest
            else if (                            around[0, 1] != tileType
                    && around[1, 0] == tileType &&                          around[1, 2] != tileType
                                                && around[2, 1] != tileType)
            {
                return "24";
            }
            // Left & right is non-forest
            else if (                            around[0, 1] == tileType
                    && around[1, 0] != tileType &&                          around[1, 2] != tileType
                                                && around[2, 1] == tileType)
            {
                return "25";
            }
            // Left & right & down is non-forest
            else if (                            around[0, 1] == tileType
                    && around[1, 0] != tileType &&                          around[1, 2] != tileType
                                                && around[2, 1] != tileType)
            {
                return "26";
            }
            // Right & up-left is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType
                    && around[1, 0] == tileType                           && around[1, 2] != tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType)
            {
                return "27";
            }
            // Left & up-right is non-forest
            else if (                          around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] != tileType                           && around[1, 2] == tileType
                    &&                           around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "28";
            }
            // Right & down-left is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType
                    && around[1, 0] == tileType                           && around[1, 2] != tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType)
            {
                return "29";
            }
            // Left & down-right is non-forest
            else if (                          around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] != tileType                           && around[1, 2] == tileType
                    &&                           around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "30";
            }
            // Right & down is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType
                    && around[1, 0] == tileType &&                          around[1, 2] != tileType
                                                && around[2, 1] != tileType)
            {
                return "31";
            }
            // Right & down & left-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType
                    && around[1, 0] == tileType &&                          around[1, 2] != tileType
                                                && around[2, 1] != tileType)
            {
                return "32";
            }
            // Left & down is non-forest
            else if (                           around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] != tileType &&                          around[1, 2] == tileType
                                                && around[2, 1] != tileType)
            {
                return "33";
            }
            // Left & down & right-up is non-forest
            else if (                           around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] != tileType &&                          around[1, 2] == tileType
                                                && around[2, 1] != tileType)
            {
                return "34";
            }
            // Right & up is non-forest
            else if (                            around[0, 1] != tileType
                    && around[1, 0] == tileType &&                          around[1, 2] != tileType
                        && around[2, 0] == tileType && around[2, 1] == tileType)
            {
                return "38";
            }
            // Right & up & left-down is non-forest
            else if (                            around[0, 1] != tileType
                    && around[1, 0] == tileType &&                          around[1, 2] != tileType
                        && around[2, 0] != tileType && around[2, 1] == tileType)
            {
                return "40";
            }
            // Left & up is non-forest
            else if (                           around[0, 1] != tileType
                    && around[1, 0] != tileType &&                          around[1, 2] == tileType
                                                && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "37";
            }
            // Left & up & right-down is non-forest
            else if (                            around[0, 1] != tileType
                    && around[1, 0] != tileType &&                          around[1, 2] == tileType
                                                && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "39";
            }
            // Up & right-down
            else if (                           around[0, 1] != tileType
                    && around[1, 0] == tileType &&                          around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "41";
            }
            // Up & left-down
            else if (                            around[0, 1] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "42";
            }
            // Up & right-down & left-down
            else if (                           around[0, 1] != tileType
                    && around[1, 0] == tileType &&                          around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "43";
            }
            // Down & right-up
            else if (  around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    &&                           around[2, 1] != tileType)
            {
                return "44";
            }
            // Down & left-up
            else if (  around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    &&                           around[2, 1] != tileType)
            {
                return "45";
            }
            // Down & right-up & left-up
            else if (  around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    &&                           around[2, 1] != tileType)
            {
                return "46";
            }
            // left-up and right-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "47";
            }
            // left-down and right-down is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "48";
            }
            // left-down and left-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "49";
            }
            // right-down and right-up is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "50";
            }
            // right-down and right-up & left-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "18";
            }
            // right-down and right-up & left-down is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "51";
            }
            // right-down and left-up & left-down is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "17";
            }
            // right-down and right-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "52";
            }
            // left & right-down and right-up is non-forest
            else if (                            around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] != tileType &&                           around[1, 2] == tileType
                    &&                            around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "53";
            }
            // right & left-down and left-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType
                    && around[1, 0] == tileType &&                           around[1, 2] != tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType)
            {
                return "54";
            }
            // right-down and left-up is non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] == tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] == tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "14";
            }
            // right-up & left-down is non-forest
            else if (around[0, 0] == tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                           around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] == tileType)
            {
                return "16";
            }
            // all corners non-forest
            else if (around[0, 0] != tileType && around[0, 1] == tileType && around[0, 2] != tileType
                    && around[1, 0] == tileType &&                         around[1, 2] == tileType
                    && around[2, 0] != tileType && around[2, 1] == tileType && around[2, 2] != tileType)
            {
                return "19";
            }
            else return "03";
        }

        private Brush GetCorrectBrush(string tileType, string[,] around){
            if (tileType == "plain")
                return (Brush)new ImageBrush(new BitmapImage(new Uri(TILES_PATH + "0" + TILES_EXT, UriKind.Relative)));
            Dictionary<string,string> typeToNum = new Dictionary<string,string>();
            typeToNum.Add("water","0");
            typeToNum.Add("forest","1");
            typeToNum.Add("mountain","2");
            return (Brush)new ImageBrush(new BitmapImage(new Uri(
                  TILES_PATH
                + (typeToNum.First(e => e.Key == tileType).Value)
                + GetTileIndexFromAround(tileType, around)
                + TILES_EXT, UriKind.Relative)));
        }

        public CurrentGameModel(WindowInterface window, CurrentGameInterface page)
        {
            this.window = window;
            this.page = page;
            FileName = GameBuilder.CURRENTGAME.OpenedFile;
            if (FileName != null)
            {
                FileName = FileName.Substring(FileName.LastIndexOf("\\") + 1);
                try
                {
                    FileName = FileName.Substring(0, GameBuilder.CURRENTGAME.OpenedFile.Count() - 5);
                }
                catch (Exception)
                {
                }
            }
            map = (Grid)page.FindName("Map");

            DrawMap();
        }

        private void DrawMap()
        {
            // Add the rows and columns needed for the map
            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Height; i++)
                map.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Width; i++)
                map.ColumnDefinitions.Add(new ColumnDefinition());

            // Put the tiles
            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Height; i++)
            {
                for (int j = 0; j < GameBuilder.CURRENTGAME.Map.Width; j++)
                {
                    Rectangle r = new Rectangle();

                    // Get the tiles and the ones around for a better rendering
                    // If tile at a border, assume the tiles around are the same
                    string[,] tiles = new string[3, 3];
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (j + x < 0 || j + x >= GameBuilder.CURRENTGAME.Map.Width
                                || i + y < 0 || i + y >= GameBuilder.CURRENTGAME.Map.Height)
                            {
                                tiles[y + 1, x + 1] = GameBuilder.CURRENTGAME.Map.getTileAt(new Core.Ressource.Position(j, i)).GetType().Name.ToLower();
                            }
                            else
                            {
                                tiles[y + 1, x + 1] = GameBuilder.CURRENTGAME.Map.getTileAt(new Core.Ressource.Position(j + x, i + y)).GetType().Name.ToLower();
                            }
                        }
                    }

                    // For each tile, associate a selection command
                    r.MouseLeftButtonDown += SelectTile;
                    r.Fill = GetCorrectBrush(tiles[1, 1], tiles);
                    map.Children.Add(r);
                    Grid.SetColumn(r, j);
                    Grid.SetRow(r, i);
                }
            }

            // Create a border element to show the selected tile
            bo = new Border();
            bo.BorderBrush = Brushes.Red;
            bo.BorderThickness = new Thickness(2);


            // Create a border element to show the selected unit's tile
            unitBo = new Border();
            unitBo.BorderBrush = Brushes.Black;
            unitBo.BorderThickness = new Thickness(2);
            unitBo.RenderTransformOrigin = new Point(0.5, 0.5);
            unitBo.RenderTransform = new ScaleTransform(0.85, 0.85);
            map.Children.Add(unitBo);

            helpBo = new Border[3];
            for (int i = 0; i < 3; i++)
            {
                helpBo[i] = new Border();
                helpBo[i].BorderBrush = Brushes.White;
                helpBo[i].BorderThickness = new Thickness(2);
                helpBo[i].Visibility = Visibility.Hidden;
                map.Children.Add(helpBo[i]);
            }

            DrawUnits();
        }

        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            int x = Grid.GetColumn(r);
            int y = Grid.GetRow(r);

            if (!map.Children.Contains(bo)) map.Children.Add(bo);
            Grid.SetColumn(bo, x);
            Grid.SetRow(bo, y);

            string tileInfo = x + ";" + y + ": " + GameBuilder.CURRENTGAME.Map.getTileAt(new Core.Ressource.Position(x, y)).GetType().Name;
            Unit TileBestDef = GameBuilder.CURRENTGAME.Map.getBestDefenderAt(new Core.Ressource.Position(x, y));
            if (TileBestDef != null)
                tileInfo += "\nOccupied by the " + TileBestDef.Race.ToString() + " race";
            else tileInfo += "\nUnoccupied";
            ((TextBlock)page.FindName("TileInfo")).Text = tileInfo;

            Button b = (Button) page.FindName("MoveOrAttack");
            if (GameBuilder.CURRENTGAME.Map.IsOccupied(new Core.Ressource.Position(x, y), GameBuilder.CURRENTGAME.FirstPlayer.Race))
            {
                b.Content = "Attack";
                b.Command = Attack;
            }
            else
            {
                b.Content = "Move";
                b.Command = Move;
            }
        }

        public void DrawUnits()
        {
            // For each player
            for (int i = 0; i < GameBuilder.CURRENTGAME.Players.Count(); i++)
            {
                // For each one of the units
                for (int no_u = 0; no_u < GameBuilder.CURRENTGAME.Players[i].Race.Units.Count(); no_u++)
                {
                    // Create an image with the unit
                    Unit u = GameBuilder.CURRENTGAME.Players[i].Race.Units[no_u];
                    Rectangle r = (Rectangle)LogicalTreeHelper.FindLogicalNode(map, "P" + i + "U" + no_u);
                    if (r == null)
                    {
                        r = new Rectangle();
                        Brush b = (Brush)new ImageBrush(new BitmapImage(new Uri(
                            UNITS_PATH +
                            u.Race.ToString().ToLower()
                            + "_unit"
                            + UNITS_EXT, UriKind.Relative)));
                        r.RenderTransformOrigin = new Point(0.5, 0.5);
                        r.RenderTransform = new ScaleTransform(0.75, 0.75);
                        r.MouseLeftButtonDown += SelectTile;
                        r.Fill = b;
                        r.Name = "P" + i + "U" + no_u;
                        map.Children.Add(r);
                    }
                    Grid.SetRow(r, u.Position.YPosition);
                    Grid.SetColumn(r, u.Position.XPosition);

                    if (u.LifePoints <= 0)
                        r.Visibility = Visibility.Hidden;
                    else
                        r.Visibility = Visibility.Visible;
                }
            }
            
            DrawUnitsInfos();
        }

        public void DrawUnitsInfos()
        {
            // For each player
            for (int i = 0; i < GameBuilder.CURRENTGAME.Players.Count(); i++)
            {
                // Create an empty list box
                ListBox lb = (ListBox)page.FindName("UnitsP" + i);
                List<RadioButton> units = new List<RadioButton>();

                // For each one of the units
                for (int no_u = 0; no_u < GameBuilder.CURRENTGAME.Players[i].Race.Units.Count(); no_u++)
                {
                    Unit u = GameBuilder.CURRENTGAME.Players[i].Race.Units[no_u];
                    Rectangle r = (Rectangle)LogicalTreeHelper.FindLogicalNode(map, "P" + i + "U" + no_u);
                    // Add the unit to the list of units
                    RadioButton bt = new RadioButton();
                    bt.Name = "Bt" + r.Name;
                    bt.GroupName = "UnitsOfP" + i;

                    bt.Content = "Unit " + no_u + " (" + u.Position + ")\n" + u.LifePoints + "/" + u.Race.Life + "PV";
                    bt.Background = Brushes.LightGreen;
                    bt.FontFamily = new FontFamily("Rockwell Extra Bold");
                    bt.FontSize = 14;
                    bt.CommandParameter = r;
                    bt.Command = SelectUnit;
                    units.Add(bt);
                    if (GameBuilder.CURRENTGAME.Players[i].Race.Units[no_u].LifePoints <= 0)
                        bt.Visibility = Visibility.Hidden;
                    else
                        bt.Visibility = Visibility.Visible;
                }
                lb.ItemsSource = units;
            }
            unitBo.Visibility = Visibility.Hidden;

            if (SelectUnitCommand.unitRect != null)
                SelectTile(SelectUnitCommand.unitRect, null);
        }

        public ICommand AbortBack
        {
            get
            {
                return new AbortBackCommand(page);
            }
        }

        public ICommand AskBack
        {
            get
            {
                return new AskBackCommand(page);
            }
        }

        public ICommand Back
        {
            get
            {
                return new BackCommand(window);
            }
        }
        
        public string FileName
        {
            get;
            set;
        }

        public ICommand Save
        {
            get
            {
                return new SaveCommand(this);
            }
        }

        public ICommand SelectUnit
        {
            get
            {
                return new SelectUnitCommand(this);
            }
        }

        public ICommand Move
        {
            get
            {
                return new MoveUnitCommand(this, page);
            }
        }

        public ICommand EndTurn
        {
            get
            {
                return new EndTurnCommand(this);
            }
        }

        public ICommand Help
        {
            get
            {
                return new HelpCommand(this);
            }
        }

        public ICommand Attack
        {
            get
            {
                return new AttackUnitCommand(this, page);
            }
        }

        /*public void RemoveUnit(Unit u)
        {
            bool found = false;
            for (int i = 0; i < GameBuilder.CURRENTGAME.Players.Length && !found; i++)
            {
                for (int n = 0; n < GameBuilder.CURRENTGAME.Players[i].Race.Units.Count && !found; n++)
                {
                    if (GameBuilder.CURRENTGAME.Players[i].Race.Units[n] == u)
                    {
                        found = true;
                        Rectangle r = (Rectangle) LogicalTreeHelper.FindLogicalNode(map, "P" + i + "U" + n);
                        r.Visibility = Visibility.Hidden;

                        for (int no = n; no < GameBuilder.CURRENTGAME.Players[i].Race.Units.Count; no++)
                        {
                            r = (Rectangle)LogicalTreeHelper.FindLogicalNode(map, "P" + i + "U" + no);
                            r.Name = "P" + i + "U" + (no-1);
                        }
                    }
                }
            }
            DrawUnitsInfos();
        }*/

        public string P1Name
        {
            get { return GameBuilder.CURRENTGAME.Players[0].Name; }
        }

        public string P2Name
        {
            get { return GameBuilder.CURRENTGAME.Players[1].Name; }
        }

        public string P1Font
        {
            get
            {
                switch (GameBuilder.CURRENTGAME.Players[0].Race.GetType().Name)
                {
                    case "Elf": return "Lucida Calligraphy";
                    case "Human": return "Engravers MT";
                    case "Orc": return "Copperplate Gothic Light";
                    default: return "Segoe US";
                }
            }
        }

        public string P2Font
        {
            get
            {
                switch (GameBuilder.CURRENTGAME.Players[1].Race.GetType().Name)
                {
                    case "Elf": return "Lucida Calligraphy";
                    case "Human": return "Engravers MT";
                    case "Orc": return "Copperplate Gothic Light";
                    default: return "Segoe US";
                }
            }
        }

        public Brush P1RaceImage
        {
            get
            {
                return new ImageBrush(new BitmapImage(
                    new Uri(UNITS_PATH
                        + GameBuilder.CURRENTGAME.Players[0].Race.GetType().Name
                        + UNITS_EXT, UriKind.Relative))) { Opacity = 0.6, Stretch = Stretch.UniformToFill };
            }
        }

        public Brush P2RaceImage
        {
            get
            {
                return new ImageBrush(new BitmapImage(
                    new Uri(UNITS_PATH
                        + GameBuilder.CURRENTGAME.Players[1].Race.GetType().Name
                        + UNITS_EXT, UriKind.Relative))) { Opacity = 0.6, Stretch = Stretch.UniformToFill };
            }
        }

        public string RemainingTurns
        {
            get
            {
                return "Remaining turns : " + GameBuilder.CURRENTGAME.NumberOfTurns;
            }
        }

        public void PlaceHelp()
        {
            helpBo.ToList<Border>().ForEach(b =>
            {
                b.Visibility = Visibility.Hidden;
            });

            if (!HelpOn)
            {
                return;
            }

            int[] moves = GameBuilder.CURRENTGAME.getBestMoves();

            for (int i = 0; i < 3; i++)
            {
                Position p = new Position(moves[i * 2], moves[i * 2 + 1]);
                Grid.SetColumn(helpBo[i], p.XPosition);
                Grid.SetRow(helpBo[i], p.YPosition);
                helpBo[i].Visibility = Visibility.Visible;
            }
        }
    }
}

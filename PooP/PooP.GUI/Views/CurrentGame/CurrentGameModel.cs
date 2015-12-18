using PooP.Core.Implementation.Games;
using PooP.Core.Interfaces.Maps;
using PooP.GUI.Views.WindowApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PooP.GUI.Views.CurrentGame
{
    public class CurrentGameModel
    {
        public WindowInterface window;

        private static string TILES_PATH = "../../images/tileset/";
        private static string TILES_EXT = ".bmp";

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

        public CurrentGameModel(WindowInterface window, Page page)
        {
            this.window = window;
            Grid map = (Grid)page.FindName("Map");

            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Height; i++)
                map.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Width; i++)
                map.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Height; i++)
            {
                for (int j = 0; j < GameBuilder.CURRENTGAME.Map.Width; j++)
                {
                    Rectangle r = new Rectangle();
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
                    r.Fill = GetCorrectBrush(tiles[1,1],tiles);
                    map.Children.Add(r);
                    Grid.SetColumn(r, j);
                    Grid.SetRow(r, i);
                }
            }
        }
    }
}

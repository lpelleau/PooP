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
                    switch (tiles[1, 1])
                    {
                        case "water": 
                            // All around are non-water tiles
                            if (                          tiles[0, 1] != "water"
                                && tiles[1, 0] != "water"                           && tiles[1, 2] != "water"
                                                          && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/13.bmp", UriKind.Relative)));
                            }
                            // Left-up is non-water
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/12.bmp", UriKind.Relative)));
                            }
                            // Right-up is non-water
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/35.bmp", UriKind.Relative)));
                            }
                            // Left, right and up are dry
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] != "water"
                                    &&                           tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/11.bmp", UriKind.Relative)));
                            }
                            // Left-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/10.bmp", UriKind.Relative)));
                            }
                            // Right-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/36.bmp", UriKind.Relative)));
                            }
                            // Left is dry
                            else if (                          tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/9.bmp", UriKind.Relative)));
                            }
                            // Right is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] != "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/15.bmp", UriKind.Relative)));
                            }
                            // Up is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/20.bmp", UriKind.Relative)));
                            }
                            // Down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/21.bmp", UriKind.Relative)));
                            }
                            // Up & down is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/22.bmp", UriKind.Relative)));
                            }
                            // Up & down & left is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/23.bmp", UriKind.Relative)));
                            }
                            // Up & down & right is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/24.bmp", UriKind.Relative)));
                            }
                            // Left & right is dry
                            else if (                            tiles[0, 1] == "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/25.bmp", UriKind.Relative)));
                            }
                            // Left & right & down is dry
                            else if (                            tiles[0, 1] == "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/26.bmp", UriKind.Relative)));
                            }
                            // Right & up-left is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] != "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/27.bmp", UriKind.Relative)));
                            }
                            // Left & up-right is dry
                            else if (                          tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/28.bmp", UriKind.Relative)));
                            }
                            // Right & down-left is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] != "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/29.bmp", UriKind.Relative)));
                            }
                            // Left & down-right is dry
                            else if (                          tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/30.bmp", UriKind.Relative)));
                            }
                            // Right & down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/31.bmp", UriKind.Relative)));
                            }
                            // Right & down & left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/32.bmp", UriKind.Relative)));
                            }
                            // Left & down is dry
                            else if (                           tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/33.bmp", UriKind.Relative)));
                            }
                            // Left & down & right-up is dry
                            else if (                           tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/34.bmp", UriKind.Relative)));
                            }
                            // Right & up is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                      && tiles[2, 0] == "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/38.bmp", UriKind.Relative)));
                            }
                            // Right & up & left-down is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                      && tiles[2, 0] != "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/40.bmp", UriKind.Relative)));
                            }
                            // Left & up is dry
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/37.bmp", UriKind.Relative)));
                            }
                            // Left & up & right-down is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/39.bmp", UriKind.Relative)));
                            }
                            // Up & right-down
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/41.bmp", UriKind.Relative)));
                            }
                            // Up & left-down
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/42.bmp", UriKind.Relative)));
                            }
                            // Up & right-down & left-down
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/43.bmp", UriKind.Relative)));
                            }
                            // Down & right-up
                            else if (  tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/44.bmp", UriKind.Relative)));
                            }
                            // Down & left-up
                            else if (  tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/45.bmp", UriKind.Relative)));
                            }
                            // Down & right-up & left-up
                            else if (  tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/46.bmp", UriKind.Relative)));
                            }
                            // left-up and right-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/47.bmp", UriKind.Relative)));
                            }
                            // left-down and right-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/48.bmp", UriKind.Relative)));
                            }
                            // left-down and left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/49.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/50.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/18.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/51.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up & left-down is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/17.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/52.bmp", UriKind.Relative)));
                            }
                            // left & right-down and right-up is dry
                            else if (                            tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] != "water" &&                           tiles[1, 2] == "water"
                                    &&                            tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/53.bmp", UriKind.Relative)));
                            }
                            // right & left-down and left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] != "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/54.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/14.bmp", UriKind.Relative)));
                            }
                            // right-up & left-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/16.bmp", UriKind.Relative)));
                            }
                            else r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/3.bmp", UriKind.Relative)));break;
                        case "plain": r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/0.bmp", UriKind.Relative))); break;
                        case "forest": r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/2.bmp", UriKind.Relative))); break;
                        case "mountain": r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/1.bmp", UriKind.Relative))); break;
                    }
                    map.Children.Add(r);
                    Grid.SetColumn(r, j);
                    Grid.SetRow(r, i);
                }
            }
        }
    }
}

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
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/013.bmp", UriKind.Relative)));
                            }
                            // Left-up is non-water
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/012.bmp", UriKind.Relative)));
                            }
                            // Right-up is non-water
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/035.bmp", UriKind.Relative)));
                            }
                            // Left, right and up are dry
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] != "water"
                                    &&                           tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/011.bmp", UriKind.Relative)));
                            }
                            // Left-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/010.bmp", UriKind.Relative)));
                            }
                            // Right-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/036.bmp", UriKind.Relative)));
                            }
                            // Left is dry
                            else if (                          tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/009.bmp", UriKind.Relative)));
                            }
                            // Right is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] != "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/015.bmp", UriKind.Relative)));
                            }
                            // Up is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/020.bmp", UriKind.Relative)));
                            }
                            // Down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/021.bmp", UriKind.Relative)));
                            }
                            // Up & down is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/022.bmp", UriKind.Relative)));
                            }
                            // Up & down & left is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/023.bmp", UriKind.Relative)));
                            }
                            // Up & down & right is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/024.bmp", UriKind.Relative)));
                            }
                            // Left & right is dry
                            else if (                            tiles[0, 1] == "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/025.bmp", UriKind.Relative)));
                            }
                            // Left & right & down is dry
                            else if (                            tiles[0, 1] == "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/026.bmp", UriKind.Relative)));
                            }
                            // Right & up-left is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] != "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/027.bmp", UriKind.Relative)));
                            }
                            // Left & up-right is dry
                            else if (                          tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/028.bmp", UriKind.Relative)));
                            }
                            // Right & down-left is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water"                           && tiles[1, 2] != "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/029.bmp", UriKind.Relative)));
                            }
                            // Left & down-right is dry
                            else if (                          tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] != "water"                           && tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/030.bmp", UriKind.Relative)));
                            }
                            // Right & down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/031.bmp", UriKind.Relative)));
                            }
                            // Right & down & left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/032.bmp", UriKind.Relative)));
                            }
                            // Left & down is dry
                            else if (                           tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/033.bmp", UriKind.Relative)));
                            }
                            // Left & down & right-up is dry
                            else if (                           tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/034.bmp", UriKind.Relative)));
                            }
                            // Right & up is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                      && tiles[2, 0] == "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/038.bmp", UriKind.Relative)));
                            }
                            // Right & up & left-down is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] != "water"
                                      && tiles[2, 0] != "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/040.bmp", UriKind.Relative)));
                            }
                            // Left & up is dry
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/037.bmp", UriKind.Relative)));
                            }
                            // Left & up & right-down is dry
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] != "water" &&                          tiles[1, 2] == "water"
                                                              && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/039.bmp", UriKind.Relative)));
                            }
                            // Up & right-down
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/041.bmp", UriKind.Relative)));
                            }
                            // Up & left-down
                            else if (                            tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/042.bmp", UriKind.Relative)));
                            }
                            // Up & right-down & left-down
                            else if (                           tiles[0, 1] != "water"
                                    && tiles[1, 0] == "water" &&                          tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/043.bmp", UriKind.Relative)));
                            }
                            // Down & right-up
                            else if (  tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/044.bmp", UriKind.Relative)));
                            }
                            // Down & left-up
                            else if (  tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/045.bmp", UriKind.Relative)));
                            }
                            // Down & right-up & left-up
                            else if (  tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    &&                           tiles[2, 1] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/046.bmp", UriKind.Relative)));
                            }
                            // left-up and right-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/047.bmp", UriKind.Relative)));
                            }
                            // left-down and right-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/048.bmp", UriKind.Relative)));
                            }
                            // left-down and left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/049.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/050.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/018.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/051.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up & left-down is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/017.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/052.bmp", UriKind.Relative)));
                            }
                            // left & right-down and right-up is dry
                            else if (                            tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] != "water" &&                           tiles[1, 2] == "water"
                                    &&                            tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/053.bmp", UriKind.Relative)));
                            }
                            // right & left-down and left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] != "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/054.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up is dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] == "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] == "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/014.bmp", UriKind.Relative)));
                            }
                            // right-up & left-down is dry
                            else if (tiles[0, 0] == "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                           tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] == "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/016.bmp", UriKind.Relative)));
                            }
                            // all corners dry
                            else if (tiles[0, 0] != "water" && tiles[0, 1] == "water" && tiles[0, 2] != "water"
                                    && tiles[1, 0] == "water" &&                         tiles[1, 2] == "water"
                                    && tiles[2, 0] != "water" && tiles[2, 1] == "water" && tiles[2, 2] != "water")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/019.bmp", UriKind.Relative)));
                            }
                            else r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/003.bmp", UriKind.Relative)));break;
                        case "plain": r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/0.bmp", UriKind.Relative))); break;
                        case "forest": 							
                            // All around are non-forest tiles
                            if (                          tiles[0, 1] != "forest"
                                && tiles[1, 0] != "forest"                           && tiles[1, 2] != "forest"
                                                          && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/113.bmp", UriKind.Relative)));
                            }
                            // Left-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest"                           && tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/112.bmp", UriKind.Relative)));
                            }
                            // Right-up is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/135.bmp", UriKind.Relative)));
                            }
                            // Left, right and up are non-forest
                            else if (                           tiles[0, 1] != "forest"
                                    && tiles[1, 0] != "forest"                           && tiles[1, 2] != "forest"
                                    &&                           tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/111.bmp", UriKind.Relative)));
                            }
                            // Left-down is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest"                           && tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/110.bmp", UriKind.Relative)));
                            }
                            // Right-down is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/136.bmp", UriKind.Relative)));
                            }
                            // Left is non-forest
                            else if (                          tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] != "forest"                           && tiles[1, 2] == "forest"
                                    &&                           tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/109.bmp", UriKind.Relative)));
                            }
                            // Right is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest"
                                    && tiles[1, 0] == "forest"                           && tiles[1, 2] != "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/115.bmp", UriKind.Relative)));
                            }
                            // Up is non-forest
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/120.bmp", UriKind.Relative)));
                            }
                            // Down is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest"                           && tiles[1, 2] == "forest"
                                    &&                           tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/121.bmp", UriKind.Relative)));
                            }
                            // Up & down is non-forest
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] == "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/122.bmp", UriKind.Relative)));
                            }
                            // Up & down & left is non-forest
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] != "forest" &&                          tiles[1, 2] == "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/123.bmp", UriKind.Relative)));
                            }
                            // Up & down & right is non-forest
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] != "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/124.bmp", UriKind.Relative)));
                            }
                            // Left & right is non-forest
                            else if (                            tiles[0, 1] == "forest"
                                    && tiles[1, 0] != "forest" &&                          tiles[1, 2] != "forest"
                                                              && tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/125.bmp", UriKind.Relative)));
                            }
                            // Left & right & down is non-forest
                            else if (                            tiles[0, 1] == "forest"
                                    && tiles[1, 0] != "forest" &&                          tiles[1, 2] != "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/126.bmp", UriKind.Relative)));
                            }
                            // Right & up-left is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest"
                                    && tiles[1, 0] == "forest"                           && tiles[1, 2] != "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/127.bmp", UriKind.Relative)));
                            }
                            // Left & up-right is non-forest
                            else if (                          tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] != "forest"                           && tiles[1, 2] == "forest"
                                    &&                           tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/128.bmp", UriKind.Relative)));
                            }
                            // Right & down-left is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest"
                                    && tiles[1, 0] == "forest"                           && tiles[1, 2] != "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/129.bmp", UriKind.Relative)));
                            }
                            // Left & down-right is non-forest
                            else if (                          tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] != "forest"                           && tiles[1, 2] == "forest"
                                    &&                           tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/130.bmp", UriKind.Relative)));
                            }
                            // Right & down is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] != "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/131.bmp", UriKind.Relative)));
                            }
                            // Right & down & left-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] != "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/132.bmp", UriKind.Relative)));
                            }
                            // Left & down is non-forest
                            else if (                           tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] != "forest" &&                          tiles[1, 2] == "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/133.bmp", UriKind.Relative)));
                            }
                            // Left & down & right-up is non-forest
                            else if (                           tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] != "forest" &&                          tiles[1, 2] == "forest"
                                                              && tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/134.bmp", UriKind.Relative)));
                            }
                            // Right & up is non-forest
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] != "forest"
                                      && tiles[2, 0] == "forest" && tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/138.bmp", UriKind.Relative)));
                            }
                            // Right & up & left-down is non-forest
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] != "forest"
                                      && tiles[2, 0] != "forest" && tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/140.bmp", UriKind.Relative)));
                            }
                            // Left & up is non-forest
                            else if (                           tiles[0, 1] != "forest"
                                    && tiles[1, 0] != "forest" &&                          tiles[1, 2] == "forest"
                                                              && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/137.bmp", UriKind.Relative)));
                            }
                            // Left & up & right-down is non-forest
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] != "forest" &&                          tiles[1, 2] == "forest"
                                                              && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/139.bmp", UriKind.Relative)));
                            }
                            // Up & right-down
                            else if (                           tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/141.bmp", UriKind.Relative)));
                            }
                            // Up & left-down
                            else if (                            tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/142.bmp", UriKind.Relative)));
                            }
                            // Up & right-down & left-down
                            else if (                           tiles[0, 1] != "forest"
                                    && tiles[1, 0] == "forest" &&                          tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/143.bmp", UriKind.Relative)));
                            }
                            // Down & right-up
                            else if (  tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    &&                           tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/144.bmp", UriKind.Relative)));
                            }
                            // Down & left-up
                            else if (  tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    &&                           tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/145.bmp", UriKind.Relative)));
                            }
                            // Down & right-up & left-up
                            else if (  tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    &&                           tiles[2, 1] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/146.bmp", UriKind.Relative)));
                            }
                            // left-up and right-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/147.bmp", UriKind.Relative)));
                            }
                            // left-down and right-down is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/148.bmp", UriKind.Relative)));
                            }
                            // left-down and left-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/149.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/150.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/118.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-down is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/151.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up & left-down is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/117.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/152.bmp", UriKind.Relative)));
                            }
                            // left & right-down and right-up is non-forest
                            else if (                            tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] != "forest" &&                           tiles[1, 2] == "forest"
                                    &&                            tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/153.bmp", UriKind.Relative)));
                            }
                            // right & left-down and left-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] != "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/154.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up is non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] == "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] == "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/114.bmp", UriKind.Relative)));
                            }
                            // right-up & left-down is non-forest
                            else if (tiles[0, 0] == "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                           tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] == "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/116.bmp", UriKind.Relative)));
                            }
                            // all corners non-forest
                            else if (tiles[0, 0] != "forest" && tiles[0, 1] == "forest" && tiles[0, 2] != "forest"
                                    && tiles[1, 0] == "forest" &&                         tiles[1, 2] == "forest"
                                    && tiles[2, 0] != "forest" && tiles[2, 1] == "forest" && tiles[2, 2] != "forest")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/119.bmp", UriKind.Relative)));
                            }
                            else r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/103.bmp", UriKind.Relative)));break;
                        case "mountain":
                            // All around are non-mountain tiles
                            if (tiles[0, 1] != "mountain"
                                && tiles[1, 0] != "mountain" && tiles[1, 2] != "mountain"
                                                          && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/213.bmp", UriKind.Relative)));
                            }
                            // Left-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/212.bmp", UriKind.Relative)));
                            }
                            // Right-up is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/235.bmp", UriKind.Relative)));
                            }
                            // Left, right and up are non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] != "mountain"
                                    && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/211.bmp", UriKind.Relative)));
                            }
                            // Left-down is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/210.bmp", UriKind.Relative)));
                            }
                            // Right-down is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/236.bmp", UriKind.Relative)));
                            }
                            // Left is non-mountain
                            else if (tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/209.bmp", UriKind.Relative)));
                            }
                            // Right is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/215.bmp", UriKind.Relative)));
                            }
                            // Up is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/220.bmp", UriKind.Relative)));
                            }
                            // Down is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/221.bmp", UriKind.Relative)));
                            }
                            // Up & down is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/222.bmp", UriKind.Relative)));
                            }
                            // Up & down & left is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/223.bmp", UriKind.Relative)));
                            }
                            // Up & down & right is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/224.bmp", UriKind.Relative)));
                            }
                            // Left & right is non-mountain
                            else if (tiles[0, 1] == "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] != "mountain"
                                                              && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/225.bmp", UriKind.Relative)));
                            }
                            // Left & right & down is non-mountain
                            else if (tiles[0, 1] == "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] != "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/226.bmp", UriKind.Relative)));
                            }
                            // Right & up-left is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/227.bmp", UriKind.Relative)));
                            }
                            // Left & up-right is non-mountain
                            else if (tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/228.bmp", UriKind.Relative)));
                            }
                            // Right & down-left is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/229.bmp", UriKind.Relative)));
                            }
                            // Left & down-right is non-mountain
                            else if (tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/230.bmp", UriKind.Relative)));
                            }
                            // Right & down is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/231.bmp", UriKind.Relative)));
                            }
                            // Right & down & left-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/232.bmp", UriKind.Relative)));
                            }
                            // Left & down is non-mountain
                            else if (tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/233.bmp", UriKind.Relative)));
                            }
                            // Left & down & right-up is non-mountain
                            else if (tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                                              && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/234.bmp", UriKind.Relative)));
                            }
                            // Right & up is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                      && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/238.bmp", UriKind.Relative)));
                            }
                            // Right & up & left-down is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                      && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/240.bmp", UriKind.Relative)));
                            }
                            // Left & up is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                                              && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/237.bmp", UriKind.Relative)));
                            }
                            // Left & up & right-down is non-mountain
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                                              && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/239.bmp", UriKind.Relative)));
                            }
                            // Up & right-down
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/241.bmp", UriKind.Relative)));
                            }
                            // Up & left-down
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/242.bmp", UriKind.Relative)));
                            }
                            // Up & right-down & left-down
                            else if (tiles[0, 1] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/243.bmp", UriKind.Relative)));
                            }
                            // Down & right-up
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/244.bmp", UriKind.Relative)));
                            }
                            // Down & left-up
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/245.bmp", UriKind.Relative)));
                            }
                            // Down & right-up & left-up
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/246.bmp", UriKind.Relative)));
                            }
                            // left-up and right-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/247.bmp", UriKind.Relative)));
                            }
                            // left-down and right-down is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/248.bmp", UriKind.Relative)));
                            }
                            // left-down and left-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/249.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/250.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/218.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up & left-down is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/251.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up & left-down is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/217.bmp", UriKind.Relative)));
                            }
                            // right-down and right-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/252.bmp", UriKind.Relative)));
                            }
                            // left & right-down and right-up is non-mountain
                            else if (tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] != "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/253.bmp", UriKind.Relative)));
                            }
                            // right & left-down and left-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] != "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/254.bmp", UriKind.Relative)));
                            }
                            // right-down and left-up is non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] == "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] == "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/214.bmp", UriKind.Relative)));
                            }
                            // right-up & left-down is non-mountain
                            else if (tiles[0, 0] == "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] == "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/216.bmp", UriKind.Relative)));
                            }
                            // all corners non-mountain
                            else if (tiles[0, 0] != "mountain" && tiles[0, 1] == "mountain" && tiles[0, 2] != "mountain"
                                    && tiles[1, 0] == "mountain" && tiles[1, 2] == "mountain"
                                    && tiles[2, 0] != "mountain" && tiles[2, 1] == "mountain" && tiles[2, 2] != "mountain")
                            {
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/219.bmp", UriKind.Relative)));
                            }
                            else r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/203.bmp", UriKind.Relative))); break;
                    }
                    map.Children.Add(r);
                    Grid.SetColumn(r, j);
                    Grid.SetRow(r, i);
                }
            }
        }
    }
}

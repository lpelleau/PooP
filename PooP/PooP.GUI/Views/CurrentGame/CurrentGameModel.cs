using PooP.Core.Implementation.Games;
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
            Grid map = (Grid) page.FindName("Map");

            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Height; i++)
                map.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Width; i++)
                map.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < GameBuilder.CURRENTGAME.Map.Height; i++){
                for (int j = 0; j < GameBuilder.CURRENTGAME.Map.Width; j++){
                    Rectangle r = new Rectangle();
                    ImageBrush brush;
                    switch (GameBuilder.CURRENTGAME.Map.getTileAt(new Core.Ressource.Position(j, i)).GetType().Name.ToLower())
                    {
                        case "water": r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/3.bmp", UriKind.Relative))); break;
                        case "plain":
                                r.Fill = (Brush)new ImageBrush(new BitmapImage(new Uri("../../images/tileset/0.bmp", UriKind.Relative))); break;
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

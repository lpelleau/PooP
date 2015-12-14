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
            
            map.ShowGridLines = true;

            for (int i = 0; i <= GameBuilder.CURRENTGAME.Map.Height; i++)
                map.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i <= GameBuilder.CURRENTGAME.Map.Width; i++)
                map.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i <= GameBuilder.CURRENTGAME.Map.Height; i++){
                for (int j = 0; j <= GameBuilder.CURRENTGAME.Map.Width; j++){
                    Rectangle r = new Rectangle();
                    switch (GameBuilder.CURRENTGAME.Map.getTileAt(new Core.Ressource.Position(j, i)).GetType().Name.ToLower())
                    {
                        case "water": r.Fill = (Brush)new BrushConverter().ConvertFromString("#0000FF"); break;
                        case "plain": r.Fill = (Brush)new BrushConverter().ConvertFromString("#AAFFAA"); break;
                        case "forest": r.Fill = (Brush)new BrushConverter().ConvertFromString("#00FF00"); break;
                        case "mountain": r.Fill = (Brush)new BrushConverter().ConvertFromString("#903F08"); break;
                    }
                    map.Children.Add(r);
                    Grid.SetColumn(r, j);
                    Grid.SetRow(r, i);
                }
            }
        }
    }
}

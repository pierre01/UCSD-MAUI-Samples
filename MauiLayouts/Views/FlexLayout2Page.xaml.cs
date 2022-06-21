using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLayouts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlexLayout2Page : ContentPage
    {
        public FlexLayout2Page()
        {
            InitializeComponent();
            var allColors = new Color[] { Colors.AliceBlue, Colors.Green, Colors.DarkGreen, Colors.DarkGrey, Colors.AliceBlue, Colors.Beige, Colors.Blue, Colors.Brown, Colors.Red, Colors.Pink, Colors.Purple, Colors.PowderBlue, Colors.Orange };
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {

                var e = new Ellipse { WidthRequest = 50, HeightRequest = 50, Fill = new SolidColorBrush( allColors[rnd.Next(0, allColors.Count() )] )};
                flexLayout.Children.Add(e);
            }

        }
    }
}

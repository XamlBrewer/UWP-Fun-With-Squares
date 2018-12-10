using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class RectanglePage : Page
    {
        public RectanglePage()
        {
            this.InitializeComponent();
        }

        private void FillSwitch_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if ((sender as ToggleSwitch).IsOn)
            {
                Rectangle.Fill = Colors.LightSteelBlue;
            }
            else
            {
                Rectangle.Fill = Colors.Transparent;
            }
        }
    }
}

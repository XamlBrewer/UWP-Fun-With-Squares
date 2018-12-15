using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class SquarePage : Page
    {
        public SquarePage()
        {
            this.InitializeComponent();
        }

        private void FillSwitch_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if ((sender as ToggleSwitch).IsOn)
            {
                Square.Fill = Colors.LightSteelBlue;
            }
            else
            {
                Square.Fill = Colors.Transparent;
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Square.RotationCenterX = Square.CenterPointX;
            Square.RotationCenterY = Square.CenterPointY;
        }
    }
}

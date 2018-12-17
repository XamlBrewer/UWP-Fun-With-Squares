using Windows.UI.Xaml.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class MotionBindingPage : Page
    {
        public MotionBindingPage()
        {
            this.InitializeComponent();
            Loaded += MotionBindingPage_Loaded;
        }

        private void MotionBindingPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            myStoryboard.Begin();
        }
    }
}

using Mvvm.Services;
using XamlBrewer.Uwp.SquarePathSample;

namespace Mvvm
{
    internal class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menus
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("HomeIcon"), Text = "Home", NavigationDestination = typeof(HomePage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("RectangleIcon"), Text = "Rectangle", NavigationDestination = typeof(RectanglePage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("SquareIcon"), Text = "Square", NavigationDestination = typeof(SquarePage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("TilesIcon"), Text = "Café Wall", NavigationDestination = typeof(CafeWallPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("BulgeIcon"), Text = "Checkerboard Bulge", NavigationDestination = typeof(BulgingCheckerboardPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("SpiralIcon"), Text = "Square Circle Spiral", NavigationDestination = typeof(SquareCircleSpiralPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("SquaresIcon"), Text = "Breathing Square", NavigationDestination = typeof(BreathingSquarePage) });
            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("InfoIcon"), Text = "About", NavigationDestination = typeof(AboutPage) });
        }
    }
}

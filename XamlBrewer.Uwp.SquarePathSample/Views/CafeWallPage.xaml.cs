using Windows.UI;
using Windows.UI.Xaml.Controls;
using XamlBrewer.Uwp.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class CafeWallPage : Page
    {
        public CafeWallPage()
        {
            this.InitializeComponent();

            RenderCanvas();
        }

        private void RenderCanvas()
        {
            var side = 119;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var blackSquare = new Square
                    {
                        Side = side,
                        Fill = Colors.Black,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (240 * i),
                        CenterPointY = 120 + (240 * j)
                    };
                    Canvas.Children.Add(blackSquare);
                    var whiteSquare = new Square
                    {
                        Side = side,
                        Fill = Colors.White,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (240 * i) + 120,
                        CenterPointY = 120 + (240 * j)
                    };
                    Canvas.Children.Add(whiteSquare);
                }
                for (int j = 0; j < 4; j++)
                {
                    var blackSquare = new Square
                    {
                        Side = side,
                        Fill = Colors.Black,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (240 * i) + 40,
                        CenterPointY = (480 * (j - 1) - 240)
                    };
                    Canvas.Children.Add(blackSquare);
                    var whiteSquare = new Square
                    {
                        Side = side,
                        Fill = Colors.White,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (240 * i) - 80,
                        CenterPointY = (480 * (j - 1) + 240)
                    };
                    Canvas.Children.Add(whiteSquare);
                }

                for (int j = 0; j < 4; j++)
                {
                    var blackSquare = new Square
                    {
                        Side = side,
                        Fill = Colors.Black,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (240 * i) - 30,
                        CenterPointY = (480 * (j - 1))
                    };
                    Canvas.Children.Add(blackSquare);
                    var whiteSquare = new Square
                    {
                        Side = side,
                        Fill = Colors.White,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (240 * i) + 90,
                        CenterPointY = (480 * (j - 1))
                    };
                    Canvas.Children.Add(whiteSquare);
                }
            }
        }
    }
}

using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using XamlBrewer.Uwp.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class SquareCircleSpiralPage : Page
    {
        public SquareCircleSpiralPage()
        {
            this.InitializeComponent();

            RenderCanvas();
        }

        private void RenderCanvas()
        {
            var size = 1200;
            var side = 36;
            var radius = 0;
            var diagonal = 56;

            for (int circles = 0; circles < 5; circles++)
            {
                radius += 100;
                var squares = (int)(2 * Math.PI * radius / diagonal);
                if (squares % 2 != 0)
                {
                    squares -= 1;
                }

                for (int i = 0; i < squares; i++)
                {
                    var square = new Square
                    {
                        Side = side,
                        Stroke = i % 2 == 0 ? Colors.White : Colors.Black,
                        StrokeThickness = 7,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (size / 2) + Math.Sin(Math.PI * 2 * i / squares) * radius,
                        CenterPointY = (size / 2) + Math.Cos(Math.PI * 2 * i / squares) * radius
                    };
                    Canvas.Children.Add(square);
                }
            }
        }
    }
}

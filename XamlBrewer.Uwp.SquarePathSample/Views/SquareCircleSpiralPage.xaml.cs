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
            var rot = 1;

            for (int circles = 0; circles < 5; circles++)
            {
                radius += 100;
                rot *= -1;
                var squares = (int)(2 * Math.PI * radius / diagonal);
                if (squares % 2 != 0)
                {
                    squares -= 1;
                }

                for (double i = 0; i < squares; i++)
                {
                    var square = new Square
                    {
                        Side = side,
                        Stroke = i % 2 == 0 ? Colors.WhiteSmoke : Colors.LightSlateGray,
                        StrokeThickness = 6,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = (size / 2) + Math.Sin(Math.PI * 2 * i / squares) * radius,
                        CenterPointY = (size / 2) + Math.Cos(Math.PI * 2 * i / squares) * radius,
                        RotationCenterX = (size / 2) + Math.Sin(Math.PI * 2 * i / squares) * radius,
                        RotationCenterY = (size / 2) + Math.Cos(Math.PI * 2 * i / squares) * radius,
                        RotationAngle = (90d - i * (360d / squares) + rot * 15d) * Math.PI / 180
                    };
                    Canvas.Children.Add(square);
                }
            }
        }
    }
}

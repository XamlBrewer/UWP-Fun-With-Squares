using System;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamlBrewer.Uwp.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class BreathingSquarePage : Page
    {
        public BreathingSquarePage()
        {
            this.InitializeComponent();

            RenderCanvas();
        }

        private void RenderCanvas()
        {
            var side = 485;

            // Back
            var backSquare = new Square
            {
                Side = 600,
                Fill = Colors.LightSteelBlue,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = 500,
                CenterPointY = 500,
                RotationCenterX = 500,
                RotationCenterY = 500
            };
            backSquare.Rendered += BackSquare_Rendered;
            Canvas.Children.Add(backSquare);

            // Front
            var square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = side / 2,
                CenterPointY = side / 2
            };
            Canvas.Children.Add(square);

            square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = 1000 - side / 2,
                CenterPointY = side / 2
            };
            Canvas.Children.Add(square);

            square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = side / 2,
                CenterPointY = 1000 - side / 2
            };
            Canvas.Children.Add(square);

            square = new Square
            {
                Side = side,
                Fill = Colors.LightSlateGray,
                Height = Canvas.Height,
                Width = Canvas.Width,
                CenterPointX = 1000 - side / 2,
                CenterPointY = 1000 - side / 2
            };
            Canvas.Children.Add(square);
        }

        private void BackSquare_Rendered(object sender, RenderedEventArgs e)
        {
            // Start animation
            var shape = e.ShapeVisual;
            var compositor = Window.Current.Compositor;
            var animation = compositor.CreateScalarKeyFrameAnimation();
            var linear = compositor.CreateLinearEasingFunction();
            animation.InsertKeyFrame(1f, 360f, linear);
            animation.Duration = TimeSpan.FromSeconds(8);
            animation.Direction = AnimationDirection.Normal;
            animation.IterationBehavior = AnimationIterationBehavior.Forever;
            shape.StartAnimation(nameof(shape.RotationAngleInDegrees), animation);
        }
    }
}

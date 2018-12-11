using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace XamlBrewer.Uwp.Controls
{
    public class Rectangle : CompositionPathHost
    {
        public static readonly DependencyProperty SideXProperty =
            DependencyProperty.Register(nameof(SideX), typeof(double), typeof(Rectangle), new PropertyMetadata(0d, Render));

        public static readonly DependencyProperty SideYProperty =
            DependencyProperty.Register(nameof(SideY), typeof(double), typeof(Rectangle), new PropertyMetadata(0d, Render));

        public double SideX
        {
            get { return (double)GetValue(SideXProperty); }
            set { SetValue(SideXProperty, value); }
        }

        public double SideY
        {
            get { return (double)GetValue(SideYProperty); }
            set { SetValue(SideYProperty, value); }
        }

        protected override void Render()
        {
            var canvasPathBuilder = GetCanvasPathBuilder();

            // Figure
            canvasPathBuilder.BeginFigure(new Vector2((float)StartPointX, (float)StartPointY));
            canvasPathBuilder.AddLine(
                new Vector2((float)(SideX + StartPointX), (float)(StartPointY)));
            canvasPathBuilder.AddLine(
                new Vector2((float)(SideX + StartPointX), (float)(SideY + StartPointY)));
            canvasPathBuilder.AddLine(
                new Vector2((float)(StartPointX), (float)(SideY + StartPointY)));
            canvasPathBuilder.EndFigure(CanvasFigureLoop.Closed);

            Render(canvasPathBuilder);
        }
    }
}

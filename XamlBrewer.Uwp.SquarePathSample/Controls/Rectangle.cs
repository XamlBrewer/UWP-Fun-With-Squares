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
            var root = Container.GetVisual();
            var compositor = Window.Current.Compositor;
            var canvasPathBuilder = new CanvasPathBuilder(new CanvasDevice());
            if (IsStrokeRounded)
            {
                canvasPathBuilder.SetSegmentOptions(CanvasFigureSegmentOptions.ForceRoundLineJoin);
            }
            else
            {
                canvasPathBuilder.SetSegmentOptions(CanvasFigureSegmentOptions.None);
            }

            // Figure
            canvasPathBuilder.BeginFigure(new Vector2((float)StartPointX, (float)StartPointY));
            canvasPathBuilder.AddLine(
                new Vector2((float)(SideX + StartPointX), (float)(StartPointY)));
            canvasPathBuilder.AddLine(
                new Vector2((float)(SideX + StartPointX), (float)(SideY + StartPointY)));
            canvasPathBuilder.AddLine(
                new Vector2((float)(StartPointX), (float)(SideY + StartPointY)));

            canvasPathBuilder.EndFigure(CanvasFigureLoop.Closed);

            // Path
            var canvasGeometry = CanvasGeometry.CreatePath(canvasPathBuilder);
            var compositionPath = new CompositionPath(canvasGeometry);
            var pathGeometry = compositor.CreatePathGeometry();
            pathGeometry.Path = compositionPath;
            var spriteShape = compositor.CreateSpriteShape(pathGeometry);
            spriteShape.FillBrush = compositor.CreateColorBrush(Fill);
            spriteShape.StrokeThickness = (float)StrokeThickness;
            spriteShape.StrokeBrush = compositor.CreateColorBrush(Stroke);
            spriteShape.StrokeStartCap = IsStrokeRounded ? CompositionStrokeCap.Round : CompositionStrokeCap.Square;
            spriteShape.StrokeEndCap = IsStrokeRounded ? CompositionStrokeCap.Round : CompositionStrokeCap.Square;

            // Visual
            var shapeVisual = compositor.CreateShapeVisual();
            shapeVisual.Size = new Vector2((float)Container.ActualWidth, (float)Container.ActualHeight);
            shapeVisual.Shapes.Add(spriteShape);
            root.Children.RemoveAll();
            root.Children.InsertAtTop(shapeVisual);
        }
    }
}

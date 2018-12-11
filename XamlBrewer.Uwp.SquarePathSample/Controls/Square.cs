using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;

namespace XamlBrewer.Uwp.Controls
{
    public class Square : CompositionPathHost
    {
        public static readonly DependencyProperty CenterPointXProperty =
            DependencyProperty.Register(nameof(CenterPointX), typeof(double), typeof(Square), new PropertyMetadata(0d, Render));

        public static readonly DependencyProperty CenterPointYProperty =
            DependencyProperty.Register(nameof(CenterPointY), typeof(double), typeof(Square), new PropertyMetadata(0d, Render));

        public static readonly DependencyProperty SideProperty =
            DependencyProperty.Register(nameof(Side), typeof(double), typeof(Square), new PropertyMetadata(0d, Render));

        public double CenterPointX
        {
            get { return (double)GetValue(CenterPointXProperty); }
            set { SetValue(CenterPointXProperty, value); }
        }

        public double CenterPointY
        {
            get { return (double)GetValue(CenterPointYProperty); }
            set { SetValue(CenterPointYProperty, value); }
        }

        public double Side
        {
            get { return (double)GetValue(SideProperty); }
            set { SetValue(SideProperty, value); }
        }

        protected override void Render()
        {
            var canvasPathBuilder = GetCanvasPathBuilder();

            // Move starting point.
            StartPointX = CenterPointX - (Side / 2);
            StartPointY = CenterPointY - (Side / 2);

            // Figure
            canvasPathBuilder.BeginFigure(new Vector2((float)StartPointX, (float)StartPointY));
            canvasPathBuilder.AddLine(
                new Vector2((float)(Side + StartPointX), (float)(StartPointY)));
            canvasPathBuilder.AddLine(
                new Vector2((float)(Side + StartPointX), (float)(Side + StartPointY)));
            canvasPathBuilder.AddLine(
                new Vector2((float)(StartPointX), (float)(Side + StartPointY)));
            canvasPathBuilder.EndFigure(CanvasFigureLoop.Closed);

            Render(canvasPathBuilder);
        }
    }
}

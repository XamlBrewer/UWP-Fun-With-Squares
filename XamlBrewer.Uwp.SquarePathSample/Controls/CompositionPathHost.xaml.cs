﻿using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.Uwp.Controls
{
    public abstract partial class CompositionPathHost : UserControl
    {
        public static readonly DependencyProperty StartPointXProperty =
            DependencyProperty.Register(nameof(StartPointX), typeof(double), typeof(CompositionPathHost), new PropertyMetadata(0d, new PropertyChangedCallback(Render)));

        public static readonly DependencyProperty StartPointYProperty =
            DependencyProperty.Register(nameof(StartPointY), typeof(double), typeof(CompositionPathHost), new PropertyMetadata(0d, Render));

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register(nameof(StrokeThickness), typeof(double), typeof(CompositionPathHost), new PropertyMetadata(1.0, Render));

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register(nameof(Stroke), typeof(Color), typeof(CompositionPathHost), new PropertyMetadata((Color)Application.Current.Resources["SystemAccentColor"], Render));

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register(nameof(Fill), typeof(Color), typeof(CompositionPathHost), new PropertyMetadata(Colors.Transparent, Render));

        public static readonly DependencyProperty IsClosedProperty =
            DependencyProperty.Register(nameof(IsClosed), typeof(bool), typeof(CompositionPathHost), new PropertyMetadata(false, Render));

        public static readonly DependencyProperty IsStrokeRoundedProperty =
            DependencyProperty.Register(nameof(IsStrokeRounded), typeof(bool), typeof(CompositionPathHost), new PropertyMetadata(false, Render));

        public double StartPointX
        {
            get { return (double)GetValue(StartPointXProperty); }
            set { SetValue(StartPointXProperty, value); }
        }

        public double StartPointY
        {
            get { return (double)GetValue(StartPointYProperty); }
            set { SetValue(StartPointYProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public Color Stroke
        {
            get { return (Color)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public Color Fill
        {
            get { return (Color)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public bool IsClosed
        {
            get { return (bool)GetValue(IsClosedProperty); }
            set { SetValue(IsClosedProperty, value); }
        }

        public bool IsStrokeRounded
        {
            get { return (bool)GetValue(IsStrokeRoundedProperty); }
            set { SetValue(IsStrokeRoundedProperty, value); }
        }

        protected Grid Container => Host;

        public CompositionPathHost()
        {
            this.InitializeComponent();

            Loaded += CompositionPathHost_Loaded;
            Unloaded += CompositionPathHost_Unloaded;
        }

        private void CompositionPathHost_Loaded(object sender, RoutedEventArgs e)
        {
            Render(this, null);
        }

        private void CompositionPathHost_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= CompositionPathHost_Loaded;
            Unloaded -= CompositionPathHost_Unloaded;
        }

        protected static void Render(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var path = (CompositionPathHost)d;
            if (path.Container.ActualWidth == 0)
            {
                return;
            }

            path.Render();
        }

        protected abstract void Render();

        // Reusable device.
        protected static CanvasDevice CanvasDevice = new CanvasDevice();

        protected CanvasPathBuilder GetCanvasPathBuilder()
        {
            var canvasPathBuilder = new CanvasPathBuilder(CanvasDevice);
            if (IsStrokeRounded)
            {
                canvasPathBuilder.SetSegmentOptions(CanvasFigureSegmentOptions.ForceRoundLineJoin);
            }
            else
            {
                canvasPathBuilder.SetSegmentOptions(CanvasFigureSegmentOptions.None);
            }

            return canvasPathBuilder;
        }

        protected void Render(CanvasPathBuilder canvasPathBuilder)
        {
            // Path
            var canvasGeometry = CanvasGeometry.CreatePath(canvasPathBuilder);
            var compositionPath = new CompositionPath(canvasGeometry);
            var compositor = Window.Current.Compositor;
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
            var root = Container.GetVisual();
            root.Children.RemoveAll();
            root.Children.InsertAtTop(shapeVisual);
        }
    }
}

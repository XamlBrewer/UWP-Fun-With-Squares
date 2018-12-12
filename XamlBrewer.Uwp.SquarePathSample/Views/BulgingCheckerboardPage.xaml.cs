using Windows.UI;
using Windows.UI.Xaml.Controls;
using XamlBrewer.Uwp.Controls;

namespace XamlBrewer.Uwp.SquarePathSample
{
    public sealed partial class BulgingCheckerboardPage : Page
    {
        public BulgingCheckerboardPage()
        {
            this.InitializeComponent();

            RenderCanvas();
        }

        private void RenderCanvas()
        {
            var side = 100;

            // Board
            for (int i = 0; i < 15; i += 2)
            {
                for (int j = 0; j < 15; j += 2)
                {
                    var blackSquare = new Square(true)
                    {
                        Side = side,
                        Fill = Colors.Black,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = i * 100 + 50,
                        CenterPointY = j * 100 + 50
                    };
                    Canvas.Children.Add(blackSquare);
                    blackSquare.DelayRendering = false;
                    blackSquare = new Square(true)
                    {
                        Side = side,
                        Fill = Colors.Black,
                        Height = Canvas.Height,
                        Width = Canvas.Width,
                        CenterPointX = i * 100 - 50,
                        CenterPointY = j * 100 - 50
                    };
                    Canvas.Children.Add(blackSquare);
                    blackSquare.DelayRendering = false;
                }
            }

            // Circle
            Square smallSquare;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i * i + j * j < 42)
                    {
                        // Quadrant 1 (top left)
                        if (j != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                StrokeThickness = 0,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) - (i * 100) - 30,
                                CenterPointY = (Canvas.Height / 2) - (j * 100) + 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }
                        if (i != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) - (i * 100) + 30,
                                CenterPointY = (Canvas.Height / 2) - (j * 100) - 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }

                        // Quadrant 2 (top right)
                        if (j != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) + (i * 100) + 30,
                                CenterPointY = (Canvas.Height / 2) - (j * 100) + 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }
                        if (i != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) + (i * 100) - 30,
                                CenterPointY = (Canvas.Height / 2) - (j * 100) - 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }
                        // Quadrant 3 (bottom left)
                        if (i != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) - (i * 100) + 30,
                                CenterPointY = (Canvas.Height / 2) + (j * 100) + 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }
                        if (j != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) - (i * 100) - 30,
                                CenterPointY = (Canvas.Height / 2) + (j * 100) - 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }

                        // Quadrant 4 (bottom right)
                        if (i != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) + (i * 100) - 30,
                                CenterPointY = (Canvas.Height / 2) + (j * 100) + 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }
                        if (j != 0)
                        {
                            smallSquare = new Square(true)
                            {
                                Side = side / 5,
                                Fill = (i + j) % 2 == 0 ? Colors.White : Colors.Black,
                                Height = Canvas.Height,
                                Width = Canvas.Width,
                                CenterPointX = (Canvas.Width / 2) + (i * 100) + 30,
                                CenterPointY = (Canvas.Height / 2) + (j * 100) - 30
                            };

                            Canvas.Children.Add(smallSquare);
                            smallSquare.DelayRendering = false;
                        }
                    }
                }
            }
        }
    }
}

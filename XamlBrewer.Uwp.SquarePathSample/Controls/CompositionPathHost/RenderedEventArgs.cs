using System;
using Windows.UI.Composition;

namespace XamlBrewer.Uwp.Controls
{
    public class RenderedEventArgs : EventArgs
    {
        public ShapeVisual ShapeVisual { get; set; }
    }
}

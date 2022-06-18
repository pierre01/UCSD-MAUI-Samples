using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGraphics.Views;

public class DrawableArea : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Drawing goes here
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 4;
        canvas.StrokeDashPattern = new float[] { 2, 2 };
        canvas.DrawLine(10, 10, 90, 100);
    }
}

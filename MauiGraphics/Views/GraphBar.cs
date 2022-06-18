using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGraphics.Views;

/// <summary>
/// Drawas a single bar based on a value
/// </summary>
public  class GraphBar : IDrawable
{
    float _barValue;

    public GraphBar(float value)
    {
        _barValue=value;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Drawing goes here
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 4;
        canvas.StrokeDashPattern = new float[] { 2, 2 };
        canvas.DrawLine(10, 10,_barValue, 10 );
    }

    public void ChangeValue(float value)
    {
        _barValue = value;
    }

}

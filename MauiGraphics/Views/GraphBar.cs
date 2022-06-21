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
    Color _trackColor   = Color.FromArgb("#FF530c0c"); 
    Color _borderColor  = Color.FromArgb("#FF404040");
    Color _valueColor   = Color.FromArgb("#FFc69595");
    //Color _valueColor = Color.FromArgb("#FF791111");

    public GraphBar(float value, Color trackColor=null, Color borderColor=null, Color valueColor=null)
    {
        _barValue=value;
        _trackColor= trackColor == null? _trackColor:trackColor;
        _borderColor=borderColor==null? _borderColor:borderColor;   
        _valueColor=valueColor == null? _valueColor:valueColor;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Drawing goes here

        canvas.FillColor = _trackColor;
        canvas.StrokeColor = _borderColor;
        canvas.StrokeSize = 2;        
        canvas.FillRoundedRectangle(2, 2, 250, 12, 4);

        canvas.FillColor = _valueColor;
        canvas.FillRoundedRectangle(2, 2, _barValue, 12, 4);
        canvas.DrawRoundedRectangle(2, 2, 250, 12, 4);
    }

    public void ChangeValue(float value)
    {
        _barValue = value;
    }

}

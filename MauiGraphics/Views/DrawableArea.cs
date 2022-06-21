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
        Random rnd = new Random();
        // Drawing goes here
        canvas.StrokeSize = 8;        
        canvas.StrokeLineCap = LineCap.Round;        
        
        // Backgtound tracks
        canvas.StrokeColor = Colors.LightGray;
        canvas.DrawArc(10, 10, 100, 100, 90, 95, true, false);
        canvas.DrawArc(20, 20, 80, 80, 90,   95, true, false);
        canvas.DrawArc(30, 30, 60, 60, 90,   95, true, false);        
        
        // Track 1
        canvas.StrokeColor = Colors.Green;
        canvas.DrawArc(10, 10, 100, 100, 90, rnd.Next(90,360),true, false);
        // Track 2
        canvas.StrokeColor = Colors.Orange;                 
        canvas.DrawArc(20, 20, 80, 80, 90, rnd.Next(90, 360), true, false);
        // Track 3
        canvas.StrokeColor = Colors.Red;                  
        canvas.DrawArc(30, 30, 60, 60, 90, rnd.Next(90, 360), true, false);
        
        


    }
}

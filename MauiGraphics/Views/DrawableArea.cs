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
        var d = DeviceDisplay.Current.MainDisplayInfo.Density;
        var w = DeviceDisplay.Current.MainDisplayInfo.Width;
        var h = DeviceDisplay.Current.MainDisplayInfo.Height;
        Random rnd = new Random();
        // Drawing goes here
        canvas.StrokeSize = 16;        
        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeColor = Colors.Yellow;
        canvas.DrawRectangle(0, 0, 400, 400);
        
        //canvas.Scale(canvas.DisplayScale, canvas.DisplayScale);

        // Backgtound tracks
        canvas.StrokeColor = Color.FromArgb("#b4cccccc");
        canvas.DrawArc(100, 100, 200, 200, 90, 95, true, false);
        canvas.DrawArc(120, 120, 160, 160, 90,   95, true, false);
        canvas.DrawArc(140, 140, 120, 120, 90,   95, true, false);        
        
        // Track 1
        canvas.StrokeColor = Colors.Green;
        canvas.DrawArc(100, 100, 200, 200, 90, rnd.Next(90,360),true, false);
        // Track 2
        canvas.StrokeColor = Colors.Orange;                 
        canvas.DrawArc(120, 120, 160, 160, 90, rnd.Next(90, 360), true, false);
        // Track 3
        canvas.StrokeColor = Colors.Red;                  
        canvas.DrawArc(140, 140, 120, 120, 90, rnd.Next(90, 360), true, false);
        
         
       


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSensors.Views;

public class CompassFace: IDrawable
{
    private double _north;

    public void SetNorth(double angle)
    {
        _north = angle;
    } 
    

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.SaveState();

        canvas.StrokeLineCap = LineCap.Round;
        canvas.FillColor = Colors.Gray;

        // Translation and scaling
        canvas.Translate(dirtyRect.Center.X, dirtyRect.Center.Y);
        float scale = Math.Min(dirtyRect.Width / 200f, dirtyRect.Height / 200f);
        canvas.Scale(scale, scale);

        // Hour and minute marks
        for (int angle = 0; angle < 360; angle += 6)
        {
            canvas.FillCircle(0, -90, angle % 30 == 0 ? 4 : 2);
            canvas.Rotate(6);
        }

        DateTime now = DateTime.Now;

        canvas.StrokeColor = Colors.OrangeRed;

        // North Pointing Hand
        canvas.StrokeSize = 10;
        canvas.SaveState();
        canvas.Rotate((float)_north);
        canvas.DrawLine(0, 0, 0, -70);
        canvas.RestoreState();



        canvas.FillCircle(0, 0, 4);
        canvas.RestoreState();

        canvas.RestoreState();

    }
}
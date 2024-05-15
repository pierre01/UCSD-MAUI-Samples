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
        var d2 = canvas.DisplayScale;
        var w2 = dirtyRect.Width;
        var h2 = dirtyRect.Height;
        var scale = w2 / 400;
        if (scale > 1)
        {
            scale = 1;
        }
        canvas.Scale(scale, scale);
        canvas.StrokeSize = 8;
        canvas.StrokeLineCap = LineCap.Round;
        canvas.StrokeColor = Colors.Yellow;
        canvas.DrawRectangle(0, 0, 400, 400);

        canvas.StrokeSize = 16;
        // Background tracks
        canvas.StrokeColor = Color.FromArgb("#b4cccccc");
        canvas.DrawArc(50, 50, 260, 260, 90, 95, true, false);
        canvas.DrawArc(74, 74, 212, 212, 90, 95, true, false);
        canvas.DrawArc(98, 98, 164, 164, 90, 95, true, false);


        // Track 1
        canvas.StrokeColor = Colors.Green;
        canvas.DrawArc(50, 50, 260, 260, 90, rnd.Next(90, 360), true, false);
        // Track 2
        canvas.StrokeColor = Colors.Orange;
        canvas.DrawArc(74, 74, 212, 212, 90, rnd.Next(90, 360), true, false);
        // Track 3
        canvas.StrokeColor = Colors.Red;
        canvas.DrawArc(98, 98, 164, 164, 90, rnd.Next(90, 360), true, false);

    }
}

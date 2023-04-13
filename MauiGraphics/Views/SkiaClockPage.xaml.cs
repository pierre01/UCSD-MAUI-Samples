using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace MauiGraphics.Views;

public partial class SkiaClockPage : ContentPage
{
    PeriodicTimer _clock;

    public SkiaClockPage()
    {
        InitializeComponent();
    }

    protected override void OnDisappearing()
    {
        _clock.Dispose();
        _clock = null;        
        
        base.OnDisappearing();

    }

    protected override async void OnAppearing()
    {
        if (_clock == null)
        {
            _clock = new PeriodicTimer(TimeSpan.FromMilliseconds(10));
        }        
        
        base.OnAppearing();

        while (await _clock.WaitForNextTickAsync())
        {
            SkiCanvas.InvalidateSurface();
        }

    }

    private void SKCanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        SKImageInfo info = e.Info;
        SKSurface surface = e.Surface;
        SKCanvas canvas = surface.Canvas;
        Rect rc = new Rect(0, 0, info.Width, info.Height);
        
        canvas.Clear();

        // Dispose
        SKPaint clockTicksPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("CCCCCC")
        };

        // Translation and scaling
        //info.Height
        canvas.Translate((float)rc.Center.X, (float)rc.Center.Y);
        float scale = Math.Min((float)rc.Width / 200f, (float)rc.Height / 200f);
        canvas.Scale(scale, scale);

        // Hour and minute marks
        for (float angle = 0; angle < 360; angle += 6)
        {
            canvas.DrawCircle(0f, -90f, angle % 30 == 0 ? 4 : 2, clockTicksPaint);
            canvas.RotateDegrees(6);
        }

        DateTime now = DateTime.Now;

        // Dispose
        SKPaint clockHourHandPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColor.Parse("e58a0f"),
            StrokeWidth = 20,
            StrokeCap = SKStrokeCap.Round

        };
        SKPaint clockMinuteHandPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColor.Parse("e58a0f"),
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round
        };
        SKPaint clockSecondHandPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColor.Parse("985b09"),
            StrokeWidth = 2
        };

        // Hour hand
        canvas.Save();
        canvas.RotateDegrees(30 * now.Hour + now.Minute / 2f);
        canvas.DrawLine(0, 0, 0, -50, clockHourHandPaint);
        canvas.Restore();

        // Minute hand
        canvas.Save();
        canvas.RotateDegrees(6 * now.Minute + now.Second / 10f);
        canvas.DrawLine(0, 0, 0, -70, clockMinuteHandPaint);
        canvas.Restore();

        // Second hand
        canvas.Save();
        var newPos = (float)now.Second + now.Millisecond/1000f ;

        canvas.RotateDegrees(6f * newPos);

        canvas.DrawLine(0, 10, 0, -80, clockSecondHandPaint);
        canvas.DrawCircle(0f, 0f,  4 , clockTicksPaint);
        canvas.Restore();

        clockSecondHandPaint.Dispose();
        clockMinuteHandPaint.Dispose();
        clockHourHandPaint.Dispose();
        clockTicksPaint.Dispose();
    }
}
using MauiGraphics.Utilities;
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
        float d = (float)ScreenGraphics.Density;
        var w = ScreenGraphics.WidthInPixels;
        var h = ScreenGraphics.WidthInPixels;
        SKImageInfo info = e.Info;
        var w3 = info.Width;
        var h3 = info.Height;
        SKSurface surface = e.Surface;
        var w2 = surface.Canvas.DeviceClipBounds.Width;
        var h2 = surface.Canvas.DeviceClipBounds.Height;
        var h4 = ScreenGraphics.HeightInDp;
        var w4 = ScreenGraphics.WidthInDp;
        var wallowed = (w3 / w2) * w;
        SKCanvas canvas = surface.Canvas;
        Rect rc = new Rect(0, 0, w3, w3);

        canvas.Clear();

        // Dispose
        SKPaint clockTicksPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("CCCCCC")
        };

        // Translation and scaling
        //info.Height
        //float scale = Math.Min((float)rc.Width / 400f, (float)rc.Height / 400f);
        canvas.Translate((float)rc.Center.X, (float)rc.Center.Y);
        canvas.Scale(d, d);

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
        var newPos = (float)now.Second + now.Millisecond / 1000f;

        canvas.RotateDegrees(6f * newPos);

        canvas.DrawLine(0, 10, 0, -80, clockSecondHandPaint);
        canvas.DrawCircle(0f, 0f, 4, clockTicksPaint);
        canvas.Restore();

        clockSecondHandPaint.Dispose();
        clockMinuteHandPaint.Dispose();
        clockHourHandPaint.Dispose();
        clockTicksPaint.Dispose();
    }
}
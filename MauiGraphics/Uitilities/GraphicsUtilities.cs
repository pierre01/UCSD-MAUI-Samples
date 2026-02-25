using Microsoft.Maui.Devices;
namespace MauiGraphics.Utilities;

public static class ScreenGraphics
{
    private static double _widthInPixels;
    private static double _heightInPixels;
    private static double _density;
    private static double _widthInDp;
    private static double _heightInDp;


    static ScreenGraphics()
    {
        _widthInPixels = DeviceDisplay.MainDisplayInfo.Width;
        _heightInPixels = DeviceDisplay.MainDisplayInfo.Height;
        _density = DeviceDisplay.MainDisplayInfo.Density;
        _widthInDp = _widthInPixels / _density;
        _heightInDp = _heightInPixels / _density;
        DeviceDisplay.MainDisplayInfoChanged += MainDisplayChanged;
    }

    private static void MainDisplayChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        _widthInPixels = DeviceDisplay.MainDisplayInfo.Width;
        _heightInPixels = DeviceDisplay.MainDisplayInfo.Height;
        _density = DeviceDisplay.MainDisplayInfo.Density;
        _widthInDp = _widthInPixels / _density;
        _heightInDp = _heightInPixels / _density;

    }

    public static double GetDpPUnitsFromPixels(double pixels)
    {
        return pixels / _density;
    }

    public static double GetPixelsFromDpUnits(double dpUnits)
    {
        return dpUnits * _density;
    }


    public static double WidthInPixels { get { return _widthInPixels; } }
    public static double HeightInPixels { get { return _heightInPixels; } }
    public static double WidthInDp { get { return _widthInDp; } }
    public static double HeightInDp { get { return _heightInDp; } }
    public static double Density { get { return _density; } }

}

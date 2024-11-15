using Microsoft.Maui.Devices;
namespace MauiLayouts;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        var di = DeviceDisplay.Current.MainDisplayInfo;
    }
}
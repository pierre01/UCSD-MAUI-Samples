namespace MauiDevices.Views;

public partial class DeviceDisplayPage : ContentPage
{
    IDeviceDisplay deviceDisplay;
    public DeviceDisplayPage(IDeviceDisplay deviceDisplay)
	{
		InitializeComponent();
        this.deviceDisplay=deviceDisplay;
        ReadDeviceDisplay(deviceDisplay.MainDisplayInfo);
        deviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
    }

    private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        ReadDeviceDisplay(e.DisplayInfo);
    }

    private void ReadDeviceDisplay(DisplayInfo display)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine($"Pixel width: {display.Width} / Pixel Height: {display.Height}");
        sb.AppendLine($"Density:     {display.Density}");
        sb.AppendLine($"Orientation: {display.Orientation}");
        sb.AppendLine($"Rotation:    {display.Rotation}");
        sb.AppendLine($"Refresh Rate:{display.RefreshRate}");

        DisplayDetailsLabel.Text = sb.ToString();
    }
    private void AlwaysOnSwitch_Toggled(object sender, ToggledEventArgs e) =>
    deviceDisplay.KeepScreenOn = AlwaysOnSwitch.IsToggled;
}
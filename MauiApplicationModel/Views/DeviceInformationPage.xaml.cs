namespace MauiApplicationModel.Views;


public partial class DeviceInformationPage : ContentPage
{
    public DeviceInformationPage()
    {
        InitializeComponent();
        ReadDeviceInfo();
    }

    private void ReadDeviceInfo()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine($"Name:    {AppInfo.Current.Name}");
        sb.AppendLine($"Package: {AppInfo.Current.PackageName}");
        sb.AppendLine($"Version: {AppInfo.Current.VersionString}");
        sb.AppendLine($"Build:   {AppInfo.Current.BuildString}");
        sb.AppendLine();
        sb.AppendLine($"Theme:   {AppInfo.Current.RequestedTheme}");
        sb.AppendLine();
        sb.AppendLine($"Model:        {DeviceInfo.Current.Model}");
        sb.AppendLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
        sb.AppendLine($"Name:         {DeviceInfo.Name}");
        sb.AppendLine($"OS Version:   {DeviceInfo.VersionString}");
        sb.AppendLine($"Idiom:        {DeviceInfo.Current.Idiom}");
        sb.AppendLine($"Platform:     {DeviceInfo.Current.Platform}");
        sb.AppendLine();
        sb.AppendLine($"Pixel width: {DeviceDisplay.Current.MainDisplayInfo.Width} / Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}");
        sb.AppendLine($"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}");
        sb.AppendLine($"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        sb.AppendLine($"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
        sb.AppendLine($"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");


        bool isVirtual = DeviceInfo.Current.DeviceType switch
        {
            DeviceType.Physical => false,
            DeviceType.Virtual => true,
            _ => false
        };

        sb.AppendLine($"Virtual device? {isVirtual}");

        DisplayDeviceLabel.Text = sb.ToString();
    }
}
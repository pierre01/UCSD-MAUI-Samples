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
        sb.AppendLine($"Refresh Rate: {DeviceInfo.Current}");
        sb.AppendLine($"Idiom:        {DeviceInfo.Current.Idiom}");
        sb.AppendLine($"Platform:     {DeviceInfo.Current.Platform}");

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
namespace MauiSensors.Views;

public partial class OrientationPage : ContentPage
{
	public OrientationPage()
	{
		InitializeComponent();
        DeviceDisplay.MainDisplayInfoChanged += DeviceDisplayOnMainDisplayInfoChanged;

    }

    private void DeviceDisplayOnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        
        OrientationLabel.Text = $"Orientation: {e.DisplayInfo.Orientation}";
    }
}
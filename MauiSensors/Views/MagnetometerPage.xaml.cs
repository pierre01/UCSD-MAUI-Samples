namespace MauiSensors.Views;

public partial class MagnetometerPage : ContentPage
{
	public MagnetometerPage()
	{
		InitializeComponent();
        ToggleMagnetometer();
	}
    private void ToggleMagnetometer()
    {
        if (Magnetometer.Default.IsSupported)
        {
            if (!Magnetometer.Default.IsMonitoring)
            {
                // Turn on compass
                Magnetometer.Default.ReadingChanged += Magnetometer_ReadingChanged;
                Magnetometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                Magnetometer.Default.Stop();
                Magnetometer.Default.ReadingChanged -= Magnetometer_ReadingChanged;
            }
        }
    }

    private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
    {
        // Update UI Label with magnetometer state
        MagnetometerLabel.TextColor = Colors.Green;
        MagnetometerLabel.Text = $"Magnetometer: {e.Reading}";
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ToggleMagnetometer();

    }
}
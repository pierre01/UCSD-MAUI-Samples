namespace MauiDeviceOutput.Views;

public partial class VibrationPage : ContentPage
{
	public VibrationPage()
	{
		InitializeComponent();
	}
    private void VibrateStartButton_Clicked(object sender, EventArgs e)
    {
        int secondsToVibrate = Random.Shared.Next(1, 7);
        TimeSpan vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

        Vibration.Default.Vibrate(vibrationLength);
    }

    private void VibrateStopButton_Clicked(object sender, EventArgs e) =>
        Vibration.Default.Cancel();
}
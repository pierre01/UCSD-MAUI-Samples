namespace MauiDeviceOutput.Views;

public partial class FlashLightPage : ContentPage
{
	public FlashLightPage()
	{
		InitializeComponent();
	}
    private async void FlashlightSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        try
        {
            if (FlashlightSwitch.IsToggled)
                await Flashlight.Default.TurnOnAsync();
            else
                await Flashlight.Default.TurnOffAsync();
        }
        catch (FeatureNotSupportedException ex)
        {
            // Handle not supported on device exception
        }
        catch (PermissionException ex)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to turn on/off flashlight
        }
    }
}
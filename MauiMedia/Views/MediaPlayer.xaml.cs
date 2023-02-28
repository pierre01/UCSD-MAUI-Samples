namespace MauiMedia.Views;

public partial class MediaPlayer : ContentPage
{
	public MediaPlayer()
	{
		InitializeComponent();
	}
    void ContentPage_Unloaded(object? sender, EventArgs e)
    {
        // Stop and cleanup MediaElement when we navigate away
        MyMediaElement.Handler?.DisconnectHandler();
    }
}
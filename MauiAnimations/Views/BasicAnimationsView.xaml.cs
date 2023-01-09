using Microsoft.Maui.Controls.Shapes;

namespace MauiAnimations.Views;

public partial class BasicAnimationsView : ContentPage
{
	public BasicAnimationsView()
	{
		InitializeComponent();
        PowLabel.Opacity=0;    
        ReloadButton.TranslateTo(300,0,100,Easing.CubicOut);
	}

    private int _shotTriggered = 0;
    private async void OnShoot(object sender, EventArgs e)
    {
        ShootButton.IsEnabled = false;
        PowLabel.Opacity=1;
        if (_shotTriggered >= 8)
        {
            // We emptied the barrel 
            PowLabel.Text = "Click!";
        }
        else
        {
            var cartridge = BarrelGrid.Children[_shotTriggered] as VisualElement;
            cartridge.FadeTo(.5, 400, Easing.CubicIn);

        }
        await Task.WhenAll
        (
             
            //TextToSpeech.Default.SpeakAsync(timeLeft),
            PowLabel.FadeTo(0, 400, Easing.CubicIn),
            PowLabel.ScaleTo(5, 400, Easing.CubicOut),

            BarrelGrid.RelRotateTo(45,600)
        );
        _shotTriggered++;
        if (_shotTriggered == 8)
        {
            // Animate Reload button
            ReloadButton.TranslateTo(0,0,500,Easing.CubicIn);

            ReloadButton.IsEnabled = true;
        }
        ShootButton.IsEnabled = true;
        PowLabel.ScaleTo(1, 40);
    }

    /// <summary>
    /// Reload button has been clicked...
    /// Change the cartridges back to new
    /// </summary>
    private void OnReload(object sender, EventArgs e)
    {
        // reload then animate away
        ReloadButton.IsEnabled = false;
        ShootButton.IsEnabled = false;
        for (int i = 0; i <= 8; i++)
        {
            var cartridge = BarrelGrid.Children[i] as VisualElement;
            // Reactivate cartridges
            cartridge.FadeTo(1, 100, Easing.CubicIn);
        }
        ReloadButton.TranslateTo(300,0,800,Easing.CubicOut);
        PowLabel.Text = "Bang!";
        _shotTriggered = 0;
        ShootButton.IsEnabled = true;
    }
}
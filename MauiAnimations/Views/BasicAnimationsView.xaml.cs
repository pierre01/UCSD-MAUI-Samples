using Microsoft.Maui.Controls.Shapes;

namespace MauiAnimations.Views;

public partial class BasicAnimationsView : ContentPage
{
	public BasicAnimationsView()
	{
		InitializeComponent();
        PowLabel.Opacity=0;    
	}

    private int _shotTriggered = 0;
    private async void OnShoot(object sender, EventArgs e)
    {
        PowLabel.Opacity=1;
        if (_shotTriggered >= 8)
        {
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
        PowLabel.ScaleTo(1, 40);
        _shotTriggered++;
    }
}
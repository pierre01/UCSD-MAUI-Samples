namespace MauiAnimations.Views;

public partial class BasicAnimationsView : ContentPage
{
    public BasicAnimationsView()
    {
        InitializeComponent();
        PowLabel.Opacity = 0;
        ReloadButton.TranslateToAsync(300, 0, 100, Easing.CubicOut);
    }

    private int _shotTriggered = 0;
    private async Task OnShoot(object sender, EventArgs e)
    {
        ShootButton.IsEnabled = false;
        PowLabel.Opacity = 1;
        if (_shotTriggered >= 8)
        {
            // We emptied the barrel 
            PowLabel.Text = "Click!";
        }
        else
        {
            var cartridge = BarrelGrid.Children[_shotTriggered] as VisualElement;
            await cartridge.FadeToAsync(.5, 400, Easing.CubicIn);

        }
        await Task.WhenAll
        (

            //TextToSpeech.Default.SpeakAsync(timeLeft),
            PowLabel.FadeToAsync(0, 400, Easing.CubicIn),
            PowLabel.ScaleToAsync(5, 400, Easing.CubicOut),
            BarrelGrid.RelRotateToAsync(45, 600)
        );
        _shotTriggered++;
        if (_shotTriggered == 8)
        {
            // Animate Reload button
            await ReloadButton.TranslateToAsync(0, 0, 500, Easing.CubicIn);

            ReloadButton.IsEnabled = true;
        }
        ShootButton.IsEnabled = true;
        await PowLabel.ScaleToAsync(1, 40);
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
            cartridge.FadeToAsync(1, 100, Easing.CubicIn);
        }
        ReloadButton.TranslateToAsync(300, 0, 800, Easing.CubicInOut);
        PowLabel.Text = "Bang!";
        _shotTriggered = 0;
        ShootButton.IsEnabled = true;
    }
}
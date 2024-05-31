namespace MauiGraphics;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    /// <summary>
    /// Sets the size running on desktop
    /// </summary>
    /// <param name="activationState"></param>
    /// <returns></returns>
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 600;
        const int newHeight = 800;
        window.X = 500;
        window.Y = 200;
        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
}

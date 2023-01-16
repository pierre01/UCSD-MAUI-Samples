namespace MauiNavigation;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 800;
        const int newHeight = 600;
        window.X = 500;
        window.Y = 200;
        window.Width = newWidth;
        window.Height = newHeight;

        window.Created += Window_Created;
        window.Activated += Window_Activated;
        window.Deactivated += Window_Deactivated;
        window.Stopped += Window_Stopped;
        window.Resumed += Window_Resumed;
        window.Destroying += Window_Destroying;


        return window;
    }

    private void Window_Destroying(object sender, EventArgs e)
    {
    }

    private void Window_Resumed(object sender, EventArgs e)
    {
    }

    private void Window_Stopped(object sender, EventArgs e)
    {
    }

    private void Window_Deactivated(object sender, EventArgs e)
    {
    }

    private void Window_Activated(object sender, EventArgs e)
    {
    }

    private void Window_Created(object sender, EventArgs e)
    {
    }
}

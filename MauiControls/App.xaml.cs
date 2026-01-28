using Microsoft.Extensions.DependencyInjection;

namespace MauiControls
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            const int newWidth = 400;
            const int newHeight = 900;
            window.X = 500;
            window.Y = 200;
            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
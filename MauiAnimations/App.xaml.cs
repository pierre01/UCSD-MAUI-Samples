using Microsoft.Extensions.DependencyInjection;

namespace MauiAnimations
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

            const int newWidth = 800;
            const int newHeight = 700;
            window.X = 500;
            window.Y = 200;
            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
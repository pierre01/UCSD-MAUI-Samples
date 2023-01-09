namespace MauiLayouts
{
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
            const int newWidth = 600;
            const int newHeight = 1000;

            window.X = 500;
            window.Y = 500;
            window.Width = newWidth;
            window.Height = newHeight;
            window.MinimumHeight = newHeight;
            return window;
        }
    }
}
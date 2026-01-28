using System.Windows.Input;

namespace MauiNavigation
{
    public partial class AppShell : Shell
    {
        public ICommand NavigateToSettingsCommand { get; private set; }

        public AppShell()
        {
            InitializeComponent();
            NavigateToSettingsCommand = new Command(() =>
            {
                DisplayAlertAsync("Settings", "Settings Menu Selected", "Ok");
            });

            BindingContext = this;
        }
    }
}

namespace MauiThemes;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        AppTheme currentTheme = Application.Current.RequestedTheme;

        ThemeLabel.Text = $"Theme is {currentTheme}";
        if (currentTheme == AppTheme.Dark)
            ThemeSwitch.IsToggled = true;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";

        SemanticScreenReader.Announce(CounterLabel.Text);
    }

    private void ThemeChanged(object sender, ToggledEventArgs e)
    {
        AppTheme currentTheme = Application.Current.UserAppTheme;
        if (currentTheme == AppTheme.Dark)
        {
            currentTheme = AppTheme.Light;
        }
        else
        {
            currentTheme = AppTheme.Dark;
        }
        Application.Current.UserAppTheme = currentTheme;
        ThemeLabel.Text = $"Theme is {currentTheme}";
    }
}
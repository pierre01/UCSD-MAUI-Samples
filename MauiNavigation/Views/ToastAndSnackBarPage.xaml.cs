using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Font = Microsoft.Maui.Font;

namespace MauiNavigation.Views;

public partial class ToastAndSnackBarPage : ContentPage
{
    public ToastAndSnackBarPage()
    {
        InitializeComponent();
        Snackbar.Dismissed += UndoPreviousAction;

    }

    private async void OnDisplayToast(object sender, EventArgs e)
    {
        if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
        {
            await DisplayAlertAsync("Alert", "Not available on Windows", "OK");
            return; 
        }

        using var cts = new CancellationTokenSource();
        var toast = Toast.Make("This is a Toast", ToastDuration.Short, 14);
        await toast.Show(cts.Token);
    }

    bool _isUndoed = false;

    private async void OnDisplaySnackBar(object sender, EventArgs e)
    {
        if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
        {
            await DisplayAlertAsync("Alert", "Not available on Windows", "OK");
            return; 
        }

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.Red,
            TextColor = Colors.Green,
            ActionButtonTextColor = Colors.Yellow,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(14),
            ActionButtonFont = Font.SystemFontOfSize(14),
            CharacterSpacing = 0.5,
        };

        string text = "This is a Snackbar";
        string actionButtonText = "Undo";
        Action action = () => _isUndoed = true;
        TimeSpan duration = TimeSpan.FromSeconds(3);

        var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

        await snackbar.Show(cancellationTokenSource.Token);

    }

    private async void UndoPreviousAction(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        if (_isUndoed == true)
        {
            _isUndoed = false;
            var toast = Toast.Make("Action Cancelled", ToastDuration.Short, 12);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            var toast = Toast.Make("Action Committed", ToastDuration.Short, 12);
            await toast.Show(cancellationTokenSource.Token);

        }

    }
}
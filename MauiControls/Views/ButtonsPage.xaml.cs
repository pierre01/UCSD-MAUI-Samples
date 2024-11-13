using System.Threading;

namespace MauiControls.Views;

public partial class ButtonsPage : ContentPage
{
    private bool _isButtonPressed; 
    private CancellationTokenSource _cancellationTokenSource;
    private int count =0;

    public ButtonsPage()
    {
        InitializeComponent();
    }


    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {

    }

    private void CheckBox_Changed(object sender, CheckedChangedEventArgs e)
    {

    }


    private void OnButtonClicked(object sender, EventArgs e)
    {
        ClickResultLabel.Text = "Clicked!";
    }

    private void OnPalmTreeButtonClicked(object sender, EventArgs e)
    {
        ClickResultPalmTree.Text = "Clicked!";
    }

    private void OnRepeatButtonPressed(object sender, EventArgs e)
    {

        _isButtonPressed = true;
        _cancellationTokenSource = new CancellationTokenSource();

        Task.Run(async () =>
        {
            while (_isButtonPressed)
            {
                Dispatcher.Dispatch(() =>
                {
                    ClickRepeatResultLabel.Text = $"Clicked! {count++} times";
                });                  
                await Task.Delay(150); // Adjust the delay as needed
            }
        }, _cancellationTokenSource.Token);
    }

    private void OnRepeatButtonReleased(object sender, EventArgs e)
    {
        _isButtonPressed = false;
        _cancellationTokenSource.Cancel();
    }

}


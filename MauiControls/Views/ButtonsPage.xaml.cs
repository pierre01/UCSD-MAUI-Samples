namespace MauiControls.Views;

public partial class ButtonsPage : ContentPage
{
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
}
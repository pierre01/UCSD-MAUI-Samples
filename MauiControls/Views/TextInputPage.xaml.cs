namespace MauiControls.Views;

public partial class TextInputPage : ContentPage
{
    public TextInputPage()
    {
        InitializeComponent();
    }

    //https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/entry?view=net-maui-8.0

    private void Name_TextChanged(object sender, TextChangedEventArgs e)
    {
        var v1 = e.NewTextValue;
        var v2 = e.OldTextValue;
        NameLabel.Text = v1;
    }

    private void Age_TextChanged(object sender, TextChangedEventArgs e)
    {
        var v1 = e.NewTextValue;
        var v2 = e.OldTextValue;
        AgeLabel.Text = v1;
    }

    private void Editor_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}
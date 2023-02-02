namespace MauiControls.Views;

public partial class TextInputPage : ContentPage
{
	public TextInputPage()
	{
		InitializeComponent();
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var v1 = e.NewTextValue;
        var v2 = e.OldTextValue;
    }

    private void Editor_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}
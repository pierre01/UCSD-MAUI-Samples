namespace MauiGraphics.Views;

public partial class BasicGraphicsPage : ContentPage
{
	public BasicGraphicsPage()
	{
		InitializeComponent();
	}

	private void RefreshButtonClicked(object sender, EventArgs e)
	{
		// Refreshes the view
        myGraphicsView.Invalidate();

    }
}
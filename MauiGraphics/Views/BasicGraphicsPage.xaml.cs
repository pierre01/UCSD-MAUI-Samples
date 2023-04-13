namespace MauiGraphics.Views;

public partial class BasicGraphicsPage : ContentPage
{
	public BasicGraphicsPage()
	{
		InitializeComponent();
		myGraphicsView.Drawable = new DrawableArea();
	}

	private void RefreshButtonClicked(object sender, EventArgs e)
	{
		// Refreshes the view
        myGraphicsView.Invalidate();

    }
}
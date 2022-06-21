namespace MauiGraphics.Views;

public partial class ParamerterizedGraphicsPage : ContentPage
{
    public GraphBar Bar01 { get; set; }
    public GraphBar Bar02 { get; set; }
    public GraphBar Bar03 { get; set; }
    public GraphBar Bar04 { get; set; }
    public ParamerterizedGraphicsPage()
	{
		InitializeComponent();
        Bar01 = new GraphBar(20);
        Bar02 = new GraphBar(200);
        Bar03 = new GraphBar(80);
        Bar04 = new GraphBar(100);
        BindingContext = this;
	}

	private void RefreshButtonClicked(object sender, EventArgs e)
	{
        Random rnd = new Random();
        ((GraphBar)B1.Drawable).ChangeValue(rnd.Next(250));
        ((GraphBar)B2.Drawable).ChangeValue(rnd.Next(250));
        ((GraphBar)B3.Drawable).ChangeValue(rnd.Next(250));
        ((GraphBar)B4.Drawable).ChangeValue(rnd.Next(250));
        B1.Invalidate();
        B2.Invalidate();
        B3.Invalidate();
        B4.Invalidate();
    }
}
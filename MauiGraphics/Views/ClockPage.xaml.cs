namespace MauiGraphics.Views;

public partial class ClockPage : ContentPage
{
    PeriodicTimer _clock;

    public ClockPage()
	{
		InitializeComponent();
	}

    protected override void OnDisappearing()
    {
        _clock.Dispose();
        _clock = null;        
        
        base.OnDisappearing();

    }

    protected override async void OnAppearing()
    {
        if (_clock == null)
        {
            _clock = new PeriodicTimer(TimeSpan.FromMilliseconds(10));
        }        
        
        base.OnAppearing();

        while (await _clock.WaitForNextTickAsync())
        {
            myGraphicsView.Invalidate();
        }

    }

}
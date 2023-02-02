namespace MauiControls.Views;

public partial class DateTimePage : ContentPage
{
	public DateTimePage()
	{
		InitializeComponent();
	}

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        var newDate = e.NewDate;
    }

    private void OnTimeChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        //var newTime = MyTimePicker.Time;
    }
}
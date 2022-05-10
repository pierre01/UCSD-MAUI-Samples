namespace MauiControls.Views;

public partial class StepAndProgress : ContentPage
{
	public StepAndProgress()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        SliderLabel.Text = e.NewValue.ToString();
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        StepperLabel.Text = e.NewValue.ToString();
    }
}
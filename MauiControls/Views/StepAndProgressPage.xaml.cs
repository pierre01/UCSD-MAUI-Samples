namespace MauiControls.Views;

public partial class StepAndProgressPage : ContentPage
{
	public StepAndProgressPage()
	{
		InitializeComponent();
        //mySlider.ValueChanged += Slider_ValueChanged;        
        //mySlider.Maximum = 15;
        //mySlider.Minimum = 5;
        //mySlider.Value = 5;


    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        SliderLabel.Text = e.NewValue.ToString("F2");
        ProgressBarExample.Progress = (e.NewValue -5)/10;
        ProgressBarLabel.Text = $"{ProgressBarExample.Progress * 100:F2}%";
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        StepperLabel.Text = e.NewValue.ToString();
    }
}
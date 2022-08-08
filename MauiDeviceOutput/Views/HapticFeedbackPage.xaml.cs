namespace MauiDeviceOutput.Views;

public partial class HapticFeedbackPage : ContentPage
{
	public HapticFeedbackPage()
	{
		InitializeComponent();
	}

    private void HapticShortButton_Clicked(object sender, EventArgs e) =>
    HapticFeedback.Default.Perform(HapticFeedbackType.Click);

    private void HapticLongButton_Clicked(object sender, EventArgs e) =>
        HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);

}
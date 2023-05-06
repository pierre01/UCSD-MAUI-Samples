namespace MAUICommunications.Views;

public partial class PhoneDialerPage : ContentPage
{
	public PhoneDialerPage()
	{
		InitializeComponent();
	}

	private void OpenDialerClicked(object sender, EventArgs e)
	{
		if (PhoneDialer.Default.IsSupported)
			PhoneDialer.Default.Open("000-000-0000");
	}
}
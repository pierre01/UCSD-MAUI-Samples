namespace MauiGraphics.Views;

public partial class BarCodeMakingPage : ContentPage
{
	public BarCodeMakingPage()
	{
		InitializeComponent();
	}

	private void QRCodeChanged(object sender, TextChangedEventArgs e)
	{
		BarcodeDisplayControl.Value = e.NewTextValue;
    }
}
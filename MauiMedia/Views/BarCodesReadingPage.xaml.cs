namespace MauiMedia.Views;

public partial class BarCodesReadingPage : ContentPage
{
	public BarCodesReadingPage()
	{
		InitializeComponent();
		//BarCodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
		//{
		//	Formats = ZXing.Net.Maui.BarcodeFormats.OneDimensional
		//}
	}

	private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		Dispatcher.Dispatch(() =>
		{
			BarcodeResultLabel.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
		});
		
	}
}
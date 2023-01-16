using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MauiMedia.Views;

public partial class BarCodesReadingPage : ContentPage
{
    private static bool IsInitialized;	
    
    public BarCodesReadingPage()
	{
		InitializeComponent();
        IsInitialized = true;
    }

    private void BarCodeReaderOnFrameReady(object sender, CameraFrameBufferEventArgs e)
    {
        _ = e.Data.Size.Height;
        //BarCodeReader.CaptureAsync();
    }

    private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		Dispatcher.Dispatch(() =>
		{
			BarcodeResultLabel.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
		});
		
	}


    private void BarCodesReadingPage_OnAppearing(object sender, EventArgs e)
    {

        if(!IsInitialized)
            InitializeComponent();
        BarCodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true

        };
        BarCodeReader.CameraLocation = CameraLocation.Rear;
        BarCodeReader.IsTorchOn = true;
        //BarCodeReader.Options = new BarcodeReaderOptions()
        BarCodeReader.FrameReady += BarCodeReaderOnFrameReady;
        BarCodeReader.BarcodesDetected += CameraBarcodeReaderView_BarcodesDetected;
        BarCodeReader.IsDetecting = true;
        
    }

    private void BarCodesReadingPage_OnDisappearing(object sender, EventArgs e)
    {
        BarCodeReader.FrameReady -= BarCodeReaderOnFrameReady;
        BarCodeReader.BarcodesDetected -= CameraBarcodeReaderView_BarcodesDetected;
        IsInitialized = false;
    }
}
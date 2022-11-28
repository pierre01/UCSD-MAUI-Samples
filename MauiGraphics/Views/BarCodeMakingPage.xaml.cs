namespace MauiGraphics.Views;

public partial class BarCodeMakingPage : ContentPage
{
	public BarCodeMakingPage()
	{
		InitializeComponent(); 
        var vcard=@"BEGIN:VCARD
N:Huguet;Pierre;;;M.Sc.
BDAY:--0531
EMAIL;TYPE=work:phuguet@ucsd.edu
URL:https://delange.design
END:VCARD";
        BarcodeDisplayControl.Value = vcard;
    }

	private void QRCodeChanged(object sender, TextChangedEventArgs e)
	{
		BarcodeDisplayControl.Value = e.NewTextValue;
    }
}
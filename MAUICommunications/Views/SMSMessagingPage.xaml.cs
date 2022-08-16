namespace MAUICommunications.Views;

public partial class SMSMessagingPage : ContentPage
{
	public SMSMessagingPage()
	{
		InitializeComponent();
	}
	public async void ComposeSms()
	{
        if (Sms.Default.IsComposeSupported)
        {
            string[] recipients = new[] { "000-000-0000" };
            string text = "Hello, I'm interested in buying your vase.";

            var message = new SmsMessage(text, recipients);

            await Sms.Default.ComposeAsync(message);
        }
    }
}
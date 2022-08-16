namespace MAUICommunications.Views;

public partial class EmailPage : ContentPage
{
	public EmailPage()
	{
		InitializeComponent();
    }

	private async Task EmailClickedAsync(object sender, EventArgs e)
	{
        if (Email.Default.IsComposeSupported)
        {

            string subject = "Hello friends!";
            string body = "It was great to see you last weekend.";
            string[] recipients = new[] { "john@contoso.com", "jane@contoso.com" };

            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                BodyFormat = EmailBodyFormat.PlainText,
                To = new List<string>(recipients)
            };

            await Email.Default.ComposeAsync(message);
        }
    }

    private async void EmailAttachementClicked(object sender, EventArgs e)
    {
        if (Email.Default.IsComposeSupported)
        {

            string subject = "Hello friends!";
            string body = "It was great to see you last weekend. I've attached a photo of our adventures together.";
            string[] recipients = new[] { "john@contoso.com", "jane@contoso.com" };

            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                BodyFormat = EmailBodyFormat.PlainText,
                To = new List<string>(recipients)
            };

            string picturePath = Path.Combine(FileSystem.CacheDirectory, "memories.jpg");

            message.Attachments.Add(new EmailAttachment(picturePath));

            await Email.Default.ComposeAsync(message);
        }
    }

    private void EmailClicked(object sender, EventArgs e)
    {

    }
}
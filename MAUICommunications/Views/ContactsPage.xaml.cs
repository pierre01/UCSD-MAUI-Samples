namespace MAUICommunications.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}
    private async void SelectContactButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var contact = await Contacts.Default.PickContactAsync();

            if (contact == null)
                return;

            string id = contact.Id;
            string namePrefix = contact.NamePrefix;
            string givenName = contact.GivenName;
            string middleName = contact.MiddleName;
            string familyName = contact.FamilyName;
            string nameSuffix = contact.NameSuffix;
            string displayName = contact.DisplayName;
            List<ContactPhone> phones = contact.Phones; // List of phone numbers
            List<ContactEmail> emails = contact.Emails; // List of email addresses
        }
        catch (Exception ex)
        {
            // Most likely permission denied
        }
    }

    public async IAsyncEnumerable<string> GetContactNames()
    {
        var contacts = await Contacts.Default.GetAllAsync();

        // No contacts
        if (contacts == null)
            yield break;

        foreach (var contact in contacts)
            yield return contact.DisplayName;
    }
}
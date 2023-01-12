using Microsoft.Maui.ApplicationModel.Communication;

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
            PermissionStatus status = await Permissions.RequestAsync<Permissions.ContactsRead>();
            //Fully Qualified Name is required because of IOS name conflict
            var contact = await Microsoft.Maui.ApplicationModel.Communication.Contacts.PickContactAsync();

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
        //Fully Qualified Name is required because of IOS name conflict
       var allContacts = await Contacts.Default.GetAllAsync();

        // No contacts
        if (allContacts == null)
            yield break;

        foreach (var contact in allContacts)
            yield return contact.DisplayName;
    }
}
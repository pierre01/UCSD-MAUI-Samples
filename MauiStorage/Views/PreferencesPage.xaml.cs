namespace MauiStorage.Views;

public partial class PreferencesPage : ContentPage
{

    const string prefKeyFirstName = "first_name";
    const string prefKeyAge = "age";
    const string prefKeyHasPet = "has_pets";
    const string prefKeyPetName = "pet_name";

    /// <summary>
    /// Prefereces deal with simple values :
    ///     Boolean
    ///     Double
    ///     Int32
    ///     Single
    ///     Int64
    ///     String
    ///     DateTime
    /// </summary>
	public PreferencesPage()
	{
		InitializeComponent();
	}

	private void SavePreferences()
	{
        // Set a string value:
        Preferences.Default.Set(prefKeyFirstName, "John");

        // Set an numerical value:
        Preferences.Default.Set(prefKeyAge, 28);

        // Set a boolean value:
        Preferences.Default.Set(prefKeyHasPet, false);
        Preferences.Default.Set(prefKeyPetName, "");
    }

    private void GetPreferences()
    {
        string firstName = Preferences.Get(prefKeyFirstName, "Unknown");
        int age = Preferences.Get(prefKeyAge, -1);
        bool hasPets = Preferences.Get(prefKeyHasPet, false);
    }

    private void ClearPreferences()
    {
        Preferences.Clear();
    }

    private void ForgetPet()
    {
        Preferences.Remove(prefKeyHasPet);
        Preferences.Remove(prefKeyPetName);
    }

}
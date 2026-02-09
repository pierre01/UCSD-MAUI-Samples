using Microsoft.Maui.Storage;
using System.Runtime.InteropServices;
namespace MauiStorage.Views;

public partial class PreferencesPage : ContentPage
{
    const string prefKeyFirstName = "first_name";
    const string prefKeyAge = "age";
    const string prefKeyHasPet = "has_pets";
    const string prefKeyPetName = "pet_name";

    string _firstName = string.Empty;
    int _age;
    bool _hasPets;
    string _petName = string.Empty;

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName == value) return;
            _firstName = value;
            OnPropertyChanged();
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (_age == value) return;
            _age = value;
            OnPropertyChanged();
        }
    }

    public bool HasPets
    {
        get => _hasPets;
        set
        {
            if (_hasPets == value) return;
            _hasPets = value;
            OnPropertyChanged();
        }
    }

    public string PetName
    {
        get => _petName;
        set
        {
            if (_petName == value) return;
            _petName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Preferences deal with simple values :
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
        BindingContext = this;
        GetPreferences();
    }

    private void GetPreferences()
    {
        // Set a string value:
        FirstName = Preferences.Default.Get(prefKeyFirstName, "John");

        // Set an numerical value:
        Age = Preferences.Default.Get(prefKeyAge, 28);

        // Set a boolean value:
        HasPets = Preferences.Default.Get(prefKeyHasPet, false);
        PetName = Preferences.Default.Get(prefKeyPetName, "");
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

    private void OnGetPreferencesClicked(object sender, EventArgs e)
    {
        GetPreferences();
    }

    private void OnClearPreferencesClicked(object sender, EventArgs e)
    {
        ClearPreferences();
    }

    private void OnForgetPetClicked(object sender, EventArgs e)
    {
        ForgetPet();
    }

    private void OnSavePreferencesClicked(object sender, EventArgs e)
    {
        SavePreferences();

    }

    private void SavePreferences()
    {
        // Set a string value:
        Preferences.Default.Set(prefKeyFirstName, FirstName);

        // Set an numerical value:
        Preferences.Default.Set(prefKeyAge, Age);

        // Set a boolean value:
        Preferences.Default.Set(prefKeyHasPet, HasPets);
        Preferences.Default.Set(prefKeyPetName, PetName );
    }
}
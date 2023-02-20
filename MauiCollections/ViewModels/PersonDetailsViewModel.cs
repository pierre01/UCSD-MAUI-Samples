using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCollections.Models;
using MauiCollections.Services;

namespace MauiCollections.ViewModels;


public partial class PersonDetailsViewModel:ObservableValidator,IQueryAttributable
{
    [ObservableProperty]
    [Required]
    [MaxLength(40)]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string   _lastName;

    [ObservableProperty]
    [Required(ErrorMessage = "First Name Required")]
    [MinLength(2, ErrorMessage = "First Name should be 2 char min")]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string   _firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Age))]
    [NotifyPropertyChangedFor(nameof(IsAgeVisible))]
    [Range(typeof(DateTime),"1/1/1900","2/2/2020",ErrorMessage = "Date of birth out of range")]
    private DateTime  _dateOfBirth;

    public int Age => (DateTime.Today - DateOfBirth).Days / 365;

    [ObservableProperty]
    private string    _gender;

    [ObservableProperty]
    private string _photo;

    [ObservableProperty] 
    private bool _isAgeVisible;

    [ObservableProperty]
    private string _errors;

    private Person _person;

    public string FullName
    {
        get { return _person.FullName; }
    }

    private INavigationService _navigationService;

    public PersonDetailsViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }


    [RelayCommand]
    public void ModifyPerson()
    {



    }

    [RelayCommand]
    public void CancelChanges()
    {
        LastName = _person.LastName;
        FirstName= _person.FirstName;
        DateOfBirth=_person.DateOfBirth;
        Gender=_person.Gender;
    }

    [RelayCommand]
    public async Task SaveChanges()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            Errors = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
            return;
        }
        else
        {
            Errors = "";
        }

        _person.LastName = LastName;
        _person.FirstName= FirstName;
        _person.DateOfBirth=DateOfBirth;
        _person.Gender=Gender;
        // Send updated Person to the server
        var navigationParameter = new Dictionary<string, object>
        {
            { "NewPerson", _person }
        };        
        await _navigationService.GoToAsync("///PersonListView", navigationParameter);
    }


    public void ApplyQueryAttributes(IDictionary<string, object> query)
    { 
        _person = query["Person"] as Person;
        if (_person.Id != 0)
        {
            LastName = _person.LastName;
            FirstName = _person.FirstName;
            DateOfBirth = _person.DateOfBirth;
            Photo = _person.Photo;
            if (Age > 30)
            {
                IsAgeVisible = false;
            }
            else
            {
                IsAgeVisible = true;
            }

            Gender = _person.Gender;
        }


    }
}
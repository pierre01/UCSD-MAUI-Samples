using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCollections.Models;
using MauiCollections.Views;
using Microsoft.Maui.Graphics;

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

    public PersonDetailsViewModel()
    {

    }

    public PersonDetailsViewModel(Person p)
    {
        LastName = p.LastName;
        FirstName= p.FirstName;
        DateOfBirth=p.DateOfBirth;
        if (Age > 30)
        {
            IsAgeVisible = false;
        }
        else
        {
            IsAgeVisible = true;
        }
        Gender=p.Gender;
        _person = p;

    }

    [RelayCommand]
    public void ModifyPerson()
    {
        LastName = "Durand";
        FirstName = "Eddie";


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
    public void SaveChanges()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            Errors = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
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
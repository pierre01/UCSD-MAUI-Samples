using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiDataBinding.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MauiDataBinding.ViewModels;

partial class PersonViewModel : ObservableValidator
{
    [ObservableProperty]
    [Required]
    [MaxLength(30)]
    public partial string LastName { get; set; }

    [ObservableProperty]
    [Required(ErrorMessage = "First Name Required")]
    [MinLength(2, ErrorMessage = "First Name should be 2 char min")]
    public partial string FirstName { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Age))]
    public partial DateTime DateOfBirth { get; set; }


    [ObservableProperty]
    public partial string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Age in years
    /// </summary>
    public int Age
    {
        get
        {
            // return the years since date of birth
            int age = (int)((DateTime.Now - DateOfBirth).TotalDays / 365.25);
            if (age < 0)
            {
                age = 0;
            }
            if (age > 30)
            {
                IsAgeVisible = false;
            }else
            {
                IsAgeVisible = true;
            }
            return age;
        }
    }


    [ObservableProperty]
    public partial string FavoriteKid { get; set; }
    public ObservableCollection<string> Children { get; set; } = new ObservableCollection<string>();

    [ObservableProperty]
    public partial bool IsAgeVisible { get; set; }

    [ObservableProperty]
    public partial string Errors { get; set; } = string.Empty;

    private Person _person;

    public PersonViewModel(Person p)
    {
        LastName = p.LastName;
        FirstName = p.FirstName;
        DateOfBirth = p.DateOfBirth;
        if (Age > 30)
        {
            IsAgeVisible = false;
        }
        else
        {
            IsAgeVisible = true;
        }
        Gender = p.Gender;
        _person = p;
        //Children.Add("Joe");
        //Children.Add("Jane");
        //Children.Add("Michael");
        //Children.Add("George");
        //Children.Add("Anna");
        //FavoriteKid = "Jane";
    }

    [RelayCommand]
    public void ModifyPerson()
    {
        LastName = "Durand";
        FirstName = "Eddie";
        //Children.Remove("Michael");
        //Children.Add("Ringo");
        //Children.Add("Bastian");
        DateOfBirth = DateTime.Today.AddYears(-25);

    }

    [RelayCommand]
    public void CancelChanges()
    {
        LastName = _person.LastName;
        FirstName = _person.FirstName;
        DateOfBirth = _person.DateOfBirth;
        Gender = _person.Gender;
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
        _person.FirstName = FirstName;
        _person.DateOfBirth = DateOfBirth;
        _person.Gender = Gender;
        // Send updated Person to the server
    }

    [RelayCommand]
    public void FavoriteChildrenChanged()
    {

    }

}
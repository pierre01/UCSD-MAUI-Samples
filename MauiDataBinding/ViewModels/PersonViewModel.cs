using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiDataBinding.Views;

namespace MauiDataBinding.ViewModels;

partial class PersonViewModel:ObservableValidator
{
    [ObservableProperty]
    [Required]
    [MaxLength(30)]
    private string   _lastName;
    [ObservableProperty]
    private string   _firstName;
    [ObservableProperty]
    private DateTime  _dateOfBirth;
    [ObservableProperty]
    private string    _gender;
    [ObservableProperty]
    private int       _age;
    [ObservableProperty]
    private string _favoriteKid;

    public ObservableCollection<string> Childrens { get; set; } = new ObservableCollection<string>();

    private Person _person;

    public PersonViewModel(Person p)
    {
        LastName = p.LastName;
        FirstName= p.FirstName;
        DateOfBirth=p.DateOfBirth;
        Gender=p.Gender;
        Age=p.Age;
        _person = p;
        Childrens.Add("Joe");
        Childrens.Add("Jane");
        Childrens.Add("Michael");
        Childrens.Add("George");
        Childrens.Add("Anna");
        FavoriteKid = "Jane";
    }

    [RelayCommand]
    public void ModifyPerson()
    {
        LastName = "Durand";
        FirstName = "Eddie";
        Childrens.Remove("Michael");
        Childrens.Add("Ringo");
        Childrens.Add("Bastian");

    }

    [RelayCommand]
    public void CancelChanges()
    {
        LastName = _person.LastName;
        FirstName= _person.FirstName;
        DateOfBirth=_person.DateOfBirth;
        Gender=_person.Gender;
        Age=_person.Age;
    }

}
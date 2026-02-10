using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCollections.Models;
using MauiCollections.Services;
using MauiCollections.Views;
using System.Collections.ObjectModel;

namespace MauiCollections.ViewModels;

public partial class PersonListViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    public partial ObservableCollection<Person> Persons { get; set; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RemovePersonCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowDetailsCommand))]
    public partial Person? SelectedPerson {get; set; }

    private IPersonDataProvider _dataprovider;

    private INavigationService _navigationService;
    public PersonListViewModel(IPersonDataProvider dataProvider, INavigationService navigationService)
    {
        _dataprovider = dataProvider;
        Persons = new ObservableCollection<Person>(_dataprovider.GetEveryone());
        SelectedPerson = null;
        _navigationService = navigationService;
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCommandOnPerson))]
    private void RemovePerson()
    {
        if (SelectedPerson == null)
        {
            return;
        }
        _dataprovider.DeletePerson(SelectedPerson.Id);
        Persons.Remove(SelectedPerson);
        SelectedPerson = null;
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCommandOnPerson))]
    private async Task ShowDetails()
    {
        if (SelectedPerson == null)
        {
            return;
        }
        // Go to the details page
        var navigationParameter = new Dictionary<string, object>
        {
            { "Person", SelectedPerson },
            { "Receipe","Banana split"}
        };
        await _navigationService.GoToAsync(nameof(PersonDetailsView), navigationParameter);
    }

    [RelayCommand]
    private async Task CreateNew()
    {
        var person = new Person(0, DateTime.MinValue, "", "", "", "");
        var navigationParameter = new Dictionary<string, object>
        {
            { "Person", person }
        };
        await _navigationService.GoToAsync(nameof(PersonDetailsView), navigationParameter);
    }

    private bool CanExecuteCommandOnPerson()
    {
        return SelectedPerson != null;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var newPerson = query["NewPerson"] as Person;
        if (newPerson == null)
        {
            return;
        }
        if (newPerson.Id == 0)
        {
            newPerson.Id = _dataprovider.AddPerson(newPerson);
            Persons.Add(newPerson);
        }
        else
        {
            // Get the position od the person in the list
            var index = Persons.IndexOf(newPerson);
            // This will force the UI to update
            Persons.Remove(newPerson);
            Persons.Insert(index, newPerson);
        }
    }
}
using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCollections.Models;
using MauiCollections.Services;
using MauiCollections.Views;

namespace MauiCollections.ViewModels;

public partial class PersonListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Person> _persons;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RemovePersonCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowDetailsCommand))]
    private Person? _selectedPerson;

    private IPersonDataProvider _dataprovider;

    public PersonListViewModel(IPersonDataProvider dataprovider )
    {
        _dataprovider = dataprovider;
        _persons = new ObservableCollection<Person>(_dataprovider.GetEveryone());
        SelectedPerson = null;
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
        SelectedPerson  = null;
        RemovePersonCommand.NotifyCanExecuteChanged();
        ShowDetailsCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCommandOnPerson))]
    private async void ShowDetails()
    {
        if (SelectedPerson == null)
        {
            return;
        }
        // Go to the details page
        var navigationParameter = new Dictionary<string, object>
        {
            { "Person", SelectedPerson }
        };
        await Shell.Current.GoToAsync(nameof(PersonDetailsView), navigationParameter);
        
    }

    private bool CanExecuteCommandOnPerson()
    {
        return SelectedPerson != null;
    }
}
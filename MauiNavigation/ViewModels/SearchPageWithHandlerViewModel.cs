using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiNavigation.Models;

namespace MauiNavigation.ViewModels;

[INotifyPropertyChanged]
public partial class SearchPageWithHandlerViewModel
{

    public SearchPageWithHandlerViewModel()
    {
        _team = new()
        {
            new Person("George"),
            new Person("Paul"),
            new Person("Pauline"),
            new Person("Michael"),
            new Person("Peter"),
            new Person("Simon"),
            new Person("Edward"),
            new Person("William"),
            new Person("Rodney"),
            new Person("Igor"),
            new Person("Richard"),
            new Person("Oliver"),
            new Person("Olivier"),
            new Person("Nathan"),
            new Person("Jim"),
            new Person("John"),
            new Person("Joe"),
            new Person("Andrew"),
            new Person("Justin"),
            new Person("Jerome"),
            new Person("Daniel"),
            new Person("Danielle"),
            new Person("Francis"),
            new Person("Franck"),
            new Person("Fred"),
            new Person("Florent"),
            new Person("Florence"),
            new Person("Guy"),
            new Person("Gus"),
            new Person("Gustave"),
            new Person("Gregory"),
            new Person("Holly"),
            new Person("Ernest"),
            new Person("Emmy"),
            new Person("Ignam"),
            new Person("Kern"),
            new Person("Louis"),
            new Person("Louise"),
            new Person("Laurent"),
            new Person("Laurence"),
            new Person("Lindsey"),
            new Person("Lark"),
            new Person("Maurice"),
            new Person("Maurine"),
            new Person("Mark"),
            new Person("Marcie"),
            new Person("Marcy"),
            new Person("Michel"),
            new Person("Noel"),
            new Person("Noemy"),
            new Person("Patrick"),
            new Person("Patricia"),
            new Person("Peter"),
            new Person("Pedro"),
            new Person("Ronald"),
            new Person("Reggie"),
            new Person("Stan"),
            new Person("Thyrone"),
            new Person("Torrey"),
            new Person("Tim"),
            new Person("Tom")
        };
        _searchResults = _team;
        
    }


    [ObservableProperty]
    public List<Person> _team ;

    [ObservableProperty] 
    public List<Person> _searchResults;

    [ObservableProperty]
    public Person _selectedPerson;
   
    
    

}
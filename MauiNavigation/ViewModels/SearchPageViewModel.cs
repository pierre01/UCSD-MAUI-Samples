using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MauiNavigation.ViewModels;

[INotifyPropertyChanged]
public partial class SearchPageViewModel
{
    public List<Person> Team { get; } = new();
    public SearchPageViewModel()
    {
        Team.Add(new Person("George"));
        Team.Add(new Person("Paul"));
        Team.Add(new Person("Pauline"));
        Team.Add(new Person("Michael"));
        Team.Add(new Person("Peter"));
        Team.Add(new Person("Simon"));
        Team.Add(new Person("Edward"));
        Team.Add(new Person("William"));
        Team.Add(new Person("Rodney"));
        Team.Add(new Person("Igor"));
        Team.Add(new Person("Richard"));
        Team.Add(new Person("Oliver"));
        Team.Add(new Person("Olivier"));
        Team.Add(new Person("Nathan"));
        Team.Add(new Person("Jim"));
        Team.Add(new Person("John"));
        Team.Add(new Person("Joe"));
        Team.Add(new Person("Andrew"));
        Team.Add(new Person("Justin"));
        Team.Add(new Person("Jerome"));
        Team.Add(new Person("Daniel"));
        Team.Add(new Person("Danielle"));
        Team.Add(new Person("Francis"));
        Team.Add(new Person("Franck"));
        Team.Add(new Person("Fred"));
        Team.Add(new Person("Florent"));
        Team.Add(new Person("Florence"));
        Team.Add(new Person("Guy"));
        Team.Add(new Person("Gus"));
        Team.Add(new Person("Gustave"));
        Team.Add(new Person("Gregory"));
        Team.Add(new Person("Holly"));
        Team.Add(new Person("Ernest"));
        Team.Add(new Person("Emmy"));
        Team.Add(new Person("Ignam"));
        Team.Add(new Person("Kern"));
        Team.Add(new Person("Louis"));
        Team.Add(new Person("Louise"));
        Team.Add(new Person("Laurent"));
        Team.Add(new Person("Laurence"));
        Team.Add(new Person("Lindsey"));
        Team.Add(new Person("Lark"));
        Team.Add(new Person("Maurice"));
        Team.Add(new Person("Maurine"));
        Team.Add(new Person("Mark"));
        Team.Add(new Person("Marcie"));
        Team.Add(new Person("Marcy"));
        Team.Add(new Person("Michel"));
        Team.Add(new Person("Noel"));
        Team.Add(new Person("Noemy"));
        Team.Add(new Person("Patrick"));
        Team.Add(new Person("Patricia"));
        Team.Add(new Person("Peter"));
        Team.Add(new Person("Pedro"));
        Team.Add(new Person("Ronald"));
        Team.Add(new Person("Reggie"));
        Team.Add(new Person("Stan"));
        Team.Add(new Person("Thyrone"));
        Team.Add(new Person("Torrey"));
        Team.Add(new Person("Tim"));
        Team.Add(new Person("Tom"));
        _searchResults = Team;
    }

    [RelayCommand]
    private void  PerformSearch(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            SearchResults = Team;
            return;
        }
        SearchResults = Team.FindAll(m =>  m.Name.ToLower().StartsWith(query.ToLower()) );
    }

    [ObservableProperty] 
    public List<Person> _searchResults;

}
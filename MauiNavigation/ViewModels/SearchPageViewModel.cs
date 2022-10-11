using System.Collections.ObjectModel;

namespace MauiNavigation.ViewModels;

public class SearchPageViewModel
{
    public ObservableCollection<Person> Team { get; } = new();
    public SearchPageViewModel()
    {

        Team.Add(new Person("George"));
        Team.Add(new Person("Paul"));
        Team.Add(new Person("Michael"));
        Team.Add(new Person("Peter"));
        Team.Add(new Person("Simon"));
        Team.Add(new Person("Edward"));
 
        Team.Add(new Person("William"));
        Team.Add(new Person("Rodney"));
        Team.Add(new Person("Igor"));
        Team.Add(new Person("Richard"));
        Team.Add(new Person("Oliver"));
        Team.Add(new Person("Nathan"));
        
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchHandlerAndroidBug.ViewModels;

public class BoysPageViewModel
{
    private ObservableCollection<Person> _boys = new();
    public ObservableCollection<Person> Boys => _boys;
    public BoysPageViewModel(int group=0)
    {
        if (group == 0)
        {
            _boys.Add(new Person("George"));
            _boys.Add(new Person("Paul"));
            _boys.Add(new Person("Michael"));
            _boys.Add(new Person("Peter"));
            _boys.Add(new Person("Simon"));
            _boys.Add(new Person("Edward"));
        }
        else
        {
            _boys.Add(new Person("William"));
            _boys.Add(new Person("Rodney"));
            _boys.Add(new Person("Igor"));
            _boys.Add(new Person("Richard"));
            _boys.Add(new Person("Oliver"));
            _boys.Add(new Person("Nathan"));
        }
    }
}

public class Person
{
    public Person(string name)
    {
        Name = name;
    }
    public String Name { get; set; }
}

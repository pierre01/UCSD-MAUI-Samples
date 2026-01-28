namespace MauiNavigation.Models;

public class Person
{
    public Person(string name)
    {
        Name = name;
    }
    public String Name { get; set; }

    public override string ToString()
    {
        return Name;
    }   
}

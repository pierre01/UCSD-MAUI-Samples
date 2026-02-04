namespace MauiDataBinding.Models;

public class Person
{
    public Person(DateTime dateOfBirth, string firstName, string lastName, string gender)
    {
        DateOfBirth = dateOfBirth;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }

    public DateTime DateOfBirth { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; } = string.Empty;
}
namespace MauiCollections.Models;

public class Person
{
    public Person(int id, DateTime dateOfBirth, string firstName, string lastName,string gender, string photo )
    {
        Id = id;
        Photo = photo;
        DateOfBirth = dateOfBirth;
        
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }
    
    public DateTime DateOfBirth { get; set; }
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string Photo { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";
}
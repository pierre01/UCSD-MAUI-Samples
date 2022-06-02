namespace MauiDataBinding.Views;

public partial class ObjectBindingPage : ContentPage
{
	public ObjectBindingPage()
	{
		InitializeComponent();
        BindingContext = new Person(DateTime.Parse("03/14/1879"), "Albert", "Einstein", "Male");
	}
}

public class Person
{
    public Person(DateTime dateOfBirth, string firstName, string lastName, string gender)
    {
        DateOfBirth = dateOfBirth;
        Age = (DateTime.Today - dateOfBirth).Days/365;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }
    
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; } = string.Empty;
}
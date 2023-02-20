using MauiCollections.Models;
using MauiCollections.Services;
using MauiCollections.ViewModels;

namespace MauiCollectionTests;

public class PersonDetailsViewModelTests
{
    private INavigationService _navigationService;
    public PersonDetailsViewModelTests()
    {
        _navigationService = new DummyNavigationService();
    }
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public async Task TestPersonAndPersonViewModel()
    {
        Person p = new Person(1, new DateTime(1969, 8, 20), "James", "Kunitz", "Male", "smiley.jpg");
        Assert.True(p.FirstName == "James", $"{nameof(p.FirstName)} should be James");
        Assert.True(p.LastName == "Kunitz", $"{nameof(p.LastName)} should be Kunitz");
        Assert.True(p.Gender == "Male", $"{nameof(p.Gender)} should be Male");
        Assert.True(p.Photo == "smiley.jpg", $"{nameof(p.Photo)} should be smiley.jpg");
        Assert.True(p.FullName == "James Kunitz", $"{nameof(p.FullName)} should be James Kunitz");
        Assert.True(p.DateOfBirth == new DateTime(1969, 8, 20), $"DOB don't match");


        var dic = new Dictionary<string, object>();
        dic.Add("Person", p); 
        PersonDetailsViewModel pv = new PersonDetailsViewModel(_navigationService);
        pv.ApplyQueryAttributes(dic);

        Assert.True(pv.FirstName == p.FirstName, $"{nameof(pv.FirstName)} should be { p.FirstName}");
        Assert.True(pv.LastName == p.LastName, $"{nameof(pv.LastName)} should be { p.LastName}");
        Assert.True(pv.Gender == p.Gender, $"{nameof(pv.Gender)} should be { p.Gender}");
        Assert.True(pv.Photo == p.Photo, $"{nameof(pv.Photo)} should be { p.Photo}");
        Assert.True(pv.FullName == p.FullName, $"{nameof(pv.FullName)} should be { p.FullName}");
        Assert.True(pv.DateOfBirth == new DateTime(1969, 8, 20), $"DOB should be {p.DateOfBirth}");
        Assert.True(pv.IsAgeVisible == false, $"AgeVisible should be false");
        await pv.SaveChanges();
        Assert.False(pv.HasErrors);
    }

    [Fact]
    public async Task TestYoungPersonViewModel()
    {
        Person p = new Person(1, new DateTime(DateTime.Today.Year, 8, 20), "James", "Kunitz", "Male", "smiley.jpg");

        var dic = new Dictionary<string, object>();
        dic.Add("Person", p); 
        PersonDetailsViewModel pv = new PersonDetailsViewModel(_navigationService);
        pv.ApplyQueryAttributes(dic);
        Assert.True(pv.IsAgeVisible == true, $"AgeVisible should be true");
        await pv.SaveChanges();
        Assert.True(pv.HasErrors);
    }

    [Fact]
    public async Task TestCancelChange()
    {
        Person p = new Person(1, new DateTime(DateTime.Today.Year, 8, 20), "James", "Kunitz", "Male", "smiley.jpg");

        var dic = new Dictionary<string, object>();
        dic.Add("Person", p); 
        PersonDetailsViewModel pv = new PersonDetailsViewModel(_navigationService);
        pv.ApplyQueryAttributes(dic);
        pv.DateOfBirth = new DateTime(1969, 5, 31);
        pv.CancelChanges();
        Assert.True(pv.DateOfBirth == p.DateOfBirth);
    }
}
using MauiCollections.Models;
using MauiCollections.ViewModels;

namespace MauiCollectionTests
{
    public class PersonDetailsViewModelTests
    {
        [Fact]
        public void TestPersonAndPersonViewModel()
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
            PersonDetailsViewModel pv = new PersonDetailsViewModel();
            pv.ApplyQueryAttributes(dic);

            Assert.True(pv.FirstName == p.FirstName, $"{nameof(pv.FirstName)} should be { p.FirstName}");
            Assert.True(pv.LastName == p.LastName, $"{nameof(pv.LastName)} should be { p.LastName}");
            Assert.True(pv.Gender == p.Gender, $"{nameof(pv.Gender)} should be { p.Gender}");
            Assert.True(pv.Photo == p.Photo, $"{nameof(pv.Photo)} should be { p.Photo}");
            Assert.True(pv.FullName == p.FullName, $"{nameof(pv.FullName)} should be { p.FullName}");
            Assert.True(pv.DateOfBirth == new DateTime(1969, 8, 20), $"DOB should be {p.DateOfBirth}");
        }
    }
}
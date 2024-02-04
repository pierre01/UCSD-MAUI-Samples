
using MauiCollections.Models;

namespace MauiCollections.Services
{
    public interface IPersonDataProvider
    {
        List<Person> GetEveryone();
        List<Person> SearchFor(string searchString);
        void DeletePerson(int Id);
        int AddPerson(Person person);
    }
}


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

    public class PersonDataProvider : IPersonDataProvider
    {
        List<Person> _people = new List<Person>();

        string[] _firstNames = new string[] {"Sam", "Joe", "Mary", "Christine","Larry","David", "Jenny","Louise","Tony","Elaine","Jane","Hugh","Felicia","Steward","Liza", "Anne", "Judy", "Annie", "David", "Clarisse", "Michael", "Edward", "Jane", "Marcus", "Claude", "Chance", "Selena",
                                            "Roberta","Jin","Florentina","Gertrude","Luce","Marie","Immelda","Johan","Ava","Sung-li","Amelia","Tom","Jonas", "Ming", "Lily","Evelyn","Iris","Maheve","Hazel","Didier","Claudine","Batiste","Sophia","Angelique","Isla","Xiaoke"};


        string[] _lastNames = new string[] { "Smith","Johnson","Brown","Williams","Jones","Garcia","Miller","Davis","Thomas", "rodriguez","Wilson","Moore", "Jackson","Martin","Lee","Perez","Lewis","Young", "Allen","King","Wright","Scott","Torres","Hill", "Green","Adams","Nelson","Baker", "Hall",
                                            "Rivera","Mitchell","Carter","Roberts","Parker", "Morris","Morgan","Peterson","Bailey","Reed","Kelly","Ramos","Kim","Cox","Ward","Brooks","Gray","Price","Sanders","Patel","Myer","Ross","Long","Perry"};

        private int _LastIndex = 53;

        public PersonDataProvider()
        {
            Random rnd = new Random();
            for (int i = 1; i < 53; i++)
            {
                var year = rnd.Next(1968, 2002);
                var day = rnd.Next(1, 28);
                var month = rnd.Next(1, 12);
                var imageName = $"image{i:D3}.jpg";
                Person p = new Person(i, new DateTime(year, month, day), _firstNames[i - 1], _lastNames[i - 1], "N/A", imageName);
                _people.Add(p);
            }
        }

        public List<Person> GetEveryone()
        {
            return _people;
        }

        public List<Person> SearchFor(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
                return _people;
            searchString = searchString.ToLower();
            return new List<Person>(_people.Where(p => p.FirstName.ToLower().Contains(searchString) || p.LastName.ToLower().Contains(searchString)));
        }

        public void DeletePerson(int Id)
        {
            _people.Remove(_people.First(p => p.Id == Id));
        }

        public int AddPerson(Person person)
        {
            person.Id = _LastIndex++;
            _people.Add(person);
            return person.Id;
        }
    }
}

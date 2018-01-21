using System.Collections.Generic;

namespace MvcModels_WebApp.Models
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        
        
        Person this[int id] { get; set; }
    }

    public class MemoryRepository : IRepository
    {
        private Dictionary<int, Person> _people = new Dictionary<int, Person> 
        {
            [1] = new Person {PersonId = 1, FirstName = "Bob", LastName = "Smith", Role = Role.Admin},
            [2] = new Person {PersonId = 2, FirstName = "Anne", LastName = "Douglas", Role = Role.User},
            [3] = new Person {PersonId = 3, FirstName = "Joe", LastName = "Able", Role = Role.User},
            [4] = new Person {PersonId = 4, FirstName = "Mary", LastName = "Peters", Role = Role.Guest}
        };

        public Person this[int id]
        {
            get => _people.ContainsKey(id) ? _people[id] : null;
            set => _people[id] = value;
        }

        public IEnumerable<Person> People => _people.Values;
    }
}
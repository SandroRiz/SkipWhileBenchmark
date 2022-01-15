using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipWhileBenchmark
{
    public static class PersonService
    {
        public static Task<Person[]> GetPeopleAsync(int howMany)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, howMany).Select(index => new Person
            {
                Id = index,
                FirstName = "John",
                Age = rng.Next(0, 100)
            }).OrderBy( p => p.Age).ToArray());
        }

        public static Person[] GetPeople(int howMany)
        {
            var rng = new Random();
            return Enumerable.Range(1, howMany).Select(index => new Person
            {
                Id = index,
                FirstName = "John",
                Age = rng.Next(0, 100)
            }).OrderBy(p => p.Age).ToArray();
        }
    }
}

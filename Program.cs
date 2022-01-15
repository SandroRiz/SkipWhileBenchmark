using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SkipWhileBenchmark;

public class Program
{
    static async Task Main(string[] args)
    {

        BenchmarkRunner.Run<Benchy>();


    }

    [MemoryDiagnoser]
    public class Benchy
    {
        const int limit = 50;
        private Person[]? people;
        
        [Params(1,10,25,50,75,90,99)]
        public int Age { get; set; }

        public Benchy()
        {
            people = PersonService.GetPeople(10000);
        }
       

        [Benchmark]
        public int WithWhere()
        {
            var peopleWhere = people.Where(x => x.Age >= this.Age);
            return peopleWhere.Count();
        }

        [Benchmark]
        public int WithSkipWhile()
        {
            var peopleSkip = people.Where(x => x.Age < this.Age);
            return peopleSkip.Count();
        }

    }
}
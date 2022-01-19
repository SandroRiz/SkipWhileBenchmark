using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SkipWhileBenchmark;

public class Program
{
    static void Main()
    {

        BenchmarkRunner.Run<Benchy>();

        //Benchy b = new();
        //b.Age = 10;
        //Console.WriteLine(b.WithWhere());
        //Console.WriteLine(b.WithSkipWhile());   
    }

    [MemoryDiagnoser]
    public class Benchy
    {
        
        private Person[] people;
        
        [Params(1,10,25,50,75,90,99)]
        public int Age { get; set; }

        public Benchy()
        {
            people = PersonService.GetPeople(100000);
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
            var peopleSkip = people.SkipWhile(x => x.Age < this.Age);
            return peopleSkip.Count();
        }

    }
}
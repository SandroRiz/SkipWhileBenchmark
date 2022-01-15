using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipWhileBenchmark
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"#{this.Id} - {this.FirstName} is {this.Age} years old";
        }
    }
}

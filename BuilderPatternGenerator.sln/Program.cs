using BuilderCommon;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample
{
    [GenerateBuilder]
    public partial class Person
    {
        public Person(string firstName, string lastName, DateTime? birthDate = default)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var x = new Person("John", "Smith", new DateTime(1980, 3, 1));
            //BuilderSourceGenerator xx = new BuilderSourceGenerator();
            //xx.Execute(new GeneratorExecutionContext());
        }
    }
}

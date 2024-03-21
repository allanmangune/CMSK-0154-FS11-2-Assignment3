using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Required validations ...");
            Person bob = new Person();
            Console.WriteLine(bob.IsValidated());

            Person kim = new Person("Kim", "Smith");
            Console.WriteLine(kim.IsValidated());
            
            Console.WriteLine("Using Entity Framework ...");

            // Set up Dependency Injection
            var serviceProvider = new ServiceCollection()
                                    .AddDbContext<Assignment3DbContext>(options =>
                                        options.UseSqlite("Data Source=assignment3.db"))
                                    .AddScoped<IPersonRepository, PersonRepository>()
                                    .BuildServiceProvider();

            // Get the PersonRepository from the service provider
            var personRepository = serviceProvider.GetService<IPersonRepository>();
            
            // Example usage
            if (personRepository != null)
            {
                AddSamplePeople(personRepository);
                Console.WriteLine("10 people added to the database.");
                ListPeople(personRepository);
                DeleteLastPerson(personRepository);
                ListPeople(personRepository);
                DeleteAllPeople(personRepository);
            }
            
        }

        static void AddSamplePeople(IPersonRepository personRepository)
        {
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", SSN = 123456789 },
                new Person { FirstName = "Jane", LastName = "Doe", SSN = 987654321 },
                new Person { FirstName = "Jim", LastName = "Beam", SSN = 123123123 },
                new Person { FirstName = "Jack", LastName = "Daniels", SSN = 321321321 },
                new Person { FirstName = "Josie", LastName = "Wales", SSN = 456456456 },
                new Person { FirstName = "Jill", LastName = "Valentine", SSN = 654654654 },
                new Person { FirstName = "Leon", LastName = "Kennedy", SSN = 111222333 },
                new Person { FirstName = "Chris", LastName = "Redfield", SSN = 444555666 },
                new Person { FirstName = "Ada", LastName = "Wong", SSN = 777888999 },
                new Person { FirstName = "Albert", LastName = "Wesker", SSN = 123987456 }
            };

            foreach (var person in people)
            {
                personRepository.Add(person);
            }
        }

        static void ListPeople(IPersonRepository personRepository)
        {
            var people = personRepository.GetAll();

            Console.WriteLine("Listing all people:");
            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.FirstName} {person.LastName}, SSN: {person.SSN}");
            }
        }

        static void DeleteLastPerson(IPersonRepository personRepository)
        {
            var people = personRepository.GetAll().ToList();
            if (people.Any())
            {
                var lastPerson = people.OrderBy(p => p.Id).LastOrDefault(); 
                if (lastPerson != null)
                {
                    personRepository.Delete(lastPerson.Id);
                    Console.WriteLine($"Deleted the last person: {lastPerson.FirstName} {lastPerson.LastName}");
                }
            }
            else
            {
                Console.WriteLine("No people found to delete.");
            }
        }

        static void DeleteAllPeople(IPersonRepository personRepository)
        {
            personRepository.DeleteAll();
            Console.WriteLine("All people have been deleted from the database.");
        }
    }
}
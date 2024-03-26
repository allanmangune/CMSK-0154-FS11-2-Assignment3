using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment3
{
    /// <summary>
    /// Represents a class that deals with the database operations.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly Assignment3DbContext _context;

        /// <summary>
        /// Constructor expects an instance of Assignment3DbContext for database operations.
        /// </summary>
        /// <param name="context"></param>
        public PersonRepository(Assignment3DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new person to the database and saves the changes.
        /// </summary>
        /// <param name="person">The person to add.</param>
        public void Add(Person person)
        {
            try
            {
                _context.People.Add(person); 
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding person to the database", ex);
            }
        }

        /// <summary>
        /// Updates an existing person in the database. If the person does not exist, an exception is thrown.
        /// </summary>
        /// <param name="person">The person with updated information.</param>
        public void Edit(Person person)
        {
            try
            {
                var existingPerson = _context.People.FirstOrDefault(p => p.Id == person.Id); 
                if (existingPerson != null)
                {
                    existingPerson.FirstName = person.FirstName;
                    existingPerson.LastName = person.LastName;
                    existingPerson.SSN = person.SSN;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Person not found");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InvalidOperationException("Error editing person in the database", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error editing person in the database", ex);
            }
        }

        /// <summary>
        /// Deletes a person from the database based on their ID. If the person is not found, no action is taken.
        /// </summary>
        /// <param name="personId">The ID of the person to delete.</param>
        public void Delete(int personId)
        {
            try
            {
                var person = _context.People.FirstOrDefault(p => p.Id == personId); 
                if (person != null)
                {
                    _context.People.Remove(person); 
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting person from the database", ex);
            }
        }

        /// <summary>
        /// Retrieves all people from the database.
        /// </summary>
        /// <returns>A list of all people.</returns>
        public IEnumerable<Person> GetAll()
        {
            try
            {
                return _context.People.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error retrieving people from the database", ex);
            }
        }

        /// <summary>
        /// Deletes all records from the People table.
        /// </summary>
        public void DeleteAll()
        {
            try
            {
                var allPeople = _context.People.ToList();
                _context.People.RemoveRange(allPeople);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting all records: {ex.Message}");
            }
        }
    }
}

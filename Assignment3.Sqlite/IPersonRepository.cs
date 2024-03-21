using System.Collections.Generic;

namespace Assignment3
{
    /// <summary>
    /// Defines a contract for a repository managing person entities.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Adds a new person to the repository.
        /// </summary>
        /// <param name="person">The person to add.</param>
        void Add(Person person);

        /// <summary>
        /// Updates an existing person in the repository.
        /// </summary>
        /// <param name="person">The person with updated information.</param>
        void Edit(Person person);

        /// <summary>
        /// Deletes a person from the repository based on their ID.
        /// </summary>
        /// <param name="personId">The ID of the person to delete.</param>
        void Delete(int personId);

        /// <summary>
        /// Retrieves all persons from the repository.
        /// </summary>
        /// <returns>A collection of all persons.</returns>
        IEnumerable<Person> GetAll();

        /// <summary>
        /// Delete all people from the database
        /// </summary>
        void DeleteAll();
    }
}

namespace Assignment3 {

    /// <summary>
    /// Represents a person with a unique Social Security Number (SSN) and a randomly generated ID.
    /// If an SSN is not provided or is zero, a unique SSN is generated automatically.
    /// </summary>
    public class Person : BaseClass
    {
        /// <summary>
        /// Gets the unique identifier for the person, generated randomly upon instantiation.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the first name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets the last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the Social Security Number (SSN) of the person.
        /// </summary>
        public int SSN { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Person class with first and last names.
        /// The ID is set to a random number, and a unique SSN is generated.
        /// </summary>
        /// <param name="firstName">The first name of the person. Defaults to an empty string.</param>
        /// <param name="lastName">The last name of the person. Defaults to an empty string.</param>
        public Person(string firstName = "", string lastName = "")
        {
            SetAttributes(firstName, lastName, 0); // SSN set to 0 to indicate it should be generated
        }

        /// <summary>
        /// Initializes a new instance of the Person class with first and last names, and an SSN.
        /// The ID is set to a random number. If the provided SSN is zero or less, a unique SSN is generated.
        /// </summary>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        /// <param name="ssn">The initial SSN of the person, if valid.</param>
        public Person(string firstName, string lastName, int ssn)
        {
            SetAttributes(firstName, lastName, ssn);
        }

        /// <summary>
        /// Validates the person by ensuring they have both a first and last name.
        /// </summary>
        /// <returns>True if the person has both a first and last name, otherwise false.</returns>
        public override bool IsValidated()
        {
            return FirstName.Length > 0 && LastName.Length > 0;
        }

        /// <summary>
        /// Assigns a new, unique SSN to the person.
        /// </summary>
        /// <returns>The new SSN.</returns>
        public int AssignSSN()
        {
            SSN = SSNumberGenerator.Instance.GenerateSSN();
            return SSN;
        }

        /// <summary>
        /// Sets the first name, last name, and ID of the person. Generates a new, unique SSN if the provided SSN is zero or less.
        /// If null is provided for either first or last name, defaults to an empty string.
        /// </summary>
        /// <param name="firstName">The first name to set.</param>
        /// <param name="lastName">The last name to set.</param>
        /// <param name="ssn">The SSN to set, generates a new one if zero or less.</param>
        private void SetAttributes(string firstName, string lastName, int ssn)
        {
            FirstName = firstName ?? string.Empty;
            LastName = lastName ?? string.Empty;
            Id = new Random().Next(1, 1000000); 
            SSN = ssn <= 0 ? SSNumberGenerator.Instance.GenerateSSN() : ssn;
        }
    }
}
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

            Console.WriteLine("Additional validations ...");
            // Create a person with an automatically generated SSN
            Person person1 = new Person("Johnny", "Bean");
            Console.WriteLine($"Person 1: {person1.FirstName} {person1.LastName}, SSN: {person1.SSN}, Validated: {person1.IsValidated()}");

            // Create another person with a specified SSN
            Person person2 = new Person("Jelly", "Coane", 1001);
            Console.WriteLine($"Person 2: {person2.FirstName} {person2.LastName}, SSN: {person2.SSN}, Validated: {person2.IsValidated()}");

            // Attempt to create a person with invalid data (empty names) to test validation
            Person person3 = new Person("", "");
            Console.WriteLine($"Person 3: {person3.FirstName} {person3.LastName}, SSN: {person3.SSN}, Validated: {person3.IsValidated()}");

            // Testing assigning a new SSN to an existing person
            int newSSN = person1.AssignSSN();
            Console.WriteLine($"Person 1 with new SSN: {person1.FirstName} {person1.LastName}, New SSN: {newSSN}");
        }
    }
}
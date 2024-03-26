namespace Assignment3{
    /// <summary>
    /// A base class with a virtual IsValidated method.
    /// </summary>
    public abstract class BaseClass
    {
        /// <summary>
        /// Gets or sets the unique identifier for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Determines if the object is in a validated state.
        /// </summary>
        /// <returns>Always returns false in the base implementation.</returns>
        public virtual bool IsValidated()
        {
            return false;
        }
    }
}



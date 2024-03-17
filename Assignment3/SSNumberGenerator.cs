namespace Assignment3
{
    /// <summary>
    /// Singleton class responsible for generating unique Social Security Numbers (SSN).
    /// </summary>
    public class SSNumberGenerator
    {
        private static SSNumberGenerator instance;
        private int lastSSN = 0;

        private SSNumberGenerator() { }

        public static SSNumberGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SSNumberGenerator();
                }
                return instance;
            }
        }

        /// <summary>
        /// Generates and returns a unique SSN.
        /// </summary>
        /// <returns>A unique SSN as an integer.</returns>
        public int GenerateSSN()
        {
            return ++lastSSN;
        }
    }
}
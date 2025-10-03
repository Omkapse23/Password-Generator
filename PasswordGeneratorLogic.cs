using System;
using System.Text;

// Define the namespace for your project
namespace PasswordGenerator
{
    // This class contains all the logic for generating a password
    public class PasswordGeneratorLogic
    {
        // Define all possible character sets as private constants
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NumericChars = "0123456789";
        private const string SymbolChars = "!@#$%^&*()-_+=[]{}|;:,.<>?";
        
        // Use a Random object for random index selection
        private readonly Random _random = new Random();

        /// <summary>
        /// Generates a random password based on the specified criteria.
        /// </summary>
        /// <param name="length">The desired length of the password.</param>
        /// <param name="includeLower">Whether to include lowercase letters.</param>
        /// <param name="includeUpper">Whether to include uppercase letters.</param>
        /// <param name="includeNumbers">Whether to include numbers.</param>
        /// <param name="includeSymbols">Whether to include symbols.</param>
        /// <returns>A randomly generated password string.</returns>
        public string GeneratePassword(int length, 
                                       bool includeLower, 
                                       bool includeUpper, 
                                       bool includeNumbers, 
                                       bool includeSymbols)
        {
            // 1. Build the character pool based on user options
            StringBuilder characterPool = new StringBuilder();

            if (includeLower)
            {
                characterPool.Append(LowercaseChars);
            }
            if (includeUpper)
            {
                characterPool.Append(UppercaseChars);
            }
            if (includeNumbers)
            {
                characterPool.Append(NumericChars);
            }
            if (includeSymbols)
            {
                characterPool.Append(SymbolChars);
            }

            string allowedChars = characterPool.ToString();

            // Check if any character set was selected
            if (allowedChars.Length == 0)
            {
                throw new InvalidOperationException("Must select at least one character set.");
            }

            // 2. Generate the password
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                // Get a random index within the allowedChars string length
                int index = _random.Next(allowedChars.Length); 
                
                // Append the character at the random index
                password.Append(allowedChars[index]);
            }

            return password.ToString();
        }
    }
}
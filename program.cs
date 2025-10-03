using System;
using PasswordGenerator; // Make sure the namespace matches your logic class

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Secure Password Generator ---");

        // Get user input
        Console.Write("Enter desired password length: ");
        int length = int.Parse(Console.ReadLine()!);

        Console.Write("Include lowercase letters? (y/n): ");
        bool includeLower = Console.ReadLine()!.Trim().ToLower() == "y";

        Console.Write("Include uppercase letters? (y/n): ");
        bool includeUpper = Console.ReadLine()!.Trim().ToLower() == "y";

        Console.Write("Include numbers? (y/n): ");
        bool includeNumbers = Console.ReadLine()!.Trim().ToLower() == "y";

        Console.Write("Include symbols? (y/n): ");
        bool includeSymbols = Console.ReadLine()!.Trim().ToLower() == "y";

        try
        {
            var generator = new PasswordGeneratorLogic();
            string password = generator.GeneratePassword(length, includeLower, includeUpper, includeNumbers, includeSymbols);
            Console.WriteLine($"\nGenerated Password: {password}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

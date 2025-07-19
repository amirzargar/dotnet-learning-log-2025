//Console Resume Builder – v1
/** This program is a simple console application that allows users to build a resume by entering their personal information, education, and work experience.
 * It then displays the complete resume in a formatted manner.
 */
/* concept cleared in this
   1. String interpolation

   2. File handling in C#

   3. Cleaner formatting

   4. Optional inputs

   5. Exit strategy with prompt*/
using System;
using System.Text.RegularExpressions;

class program
{
    public static void Main(string[] args)
    {
        File.WriteAllText("resume.txt", ""); // Clear the file at the start of each run
        while (true)
        {
            
            Console.Clear(); // clears console screen once the program starts or restarts in case user wants to add another user
            Console.WriteLine("=================================");
            Console.WriteLine("       MINI RESUME BUILDER");
            Console.WriteLine("=================================\n");

            string name = GetValidString("Enter your full name: ");
            int age = GetValidInt("Enter your age: ");
            string email = GetValidEmail("Enter your email: ");
            string city = GetValidString("Enter your city: ");

            Console.Clear();
            Console.WriteLine("\n======= USER RESUME SUMMARY =======");
            Console.WriteLine($"Name     : {name}");
            Console.WriteLine($"Age      : {age}");
            Console.WriteLine($"Email    : {email}");
            Console.WriteLine($"City     : {city}");
            Console.WriteLine("===================================");

            //saving data to txt file

            string pathfile = "resume.txt";
            string resumeContent = $"\nName: {name}\nAge: {age}\nEmail: {email}\nCity: {city}";
            try
            {
                System.IO.File.AppendAllText(pathfile, resumeContent+Environment.NewLine); // Appends the resume content to the file
                Console.WriteLine($"Resume saved successfully to {pathfile}");
            }
            catch (Exception ex)

            {
                Console.WriteLine($"❌ Error saving resume: {ex.Message}");
            }

            Console.Write("\nDo you want to add another user? (yes/no): ");
            string again = Console.ReadLine().Trim().ToLower();

            if (again != "yes")
            {
                Console.WriteLine("Exiting program...");
                break;
            }
        }
    }

    static string Prompt(string message)   // method to prompt user for input
    {
        Console.Write(message);
        string input = Console.ReadLine().Trim();
        if (input.ToLower() == "exit")
        {
            Console.WriteLine("User exited the program.");
            Environment.Exit(0);
        }
        return input;
    }

    static string GetValidString(string message)  //method to get a valid string input from the user
    {
        string input = Prompt(message);
        while (int.TryParse(input, out _))
        {
            Console.WriteLine("❌ Invalid. Enter only letters.");
            input = Prompt(message);
        }
        return input;
    }

    static int GetValidInt(string message)  //method to get a valid integer input from the user
    {
        int number;
        while (!int.TryParse(Prompt(message), out number))
        {
            Console.WriteLine("❌ Invalid. Enter numbers only.");
        }
        return number;
    }

    static string GetValidEmail(string message) //method to get a valid email input from the user
    {
        string input = Prompt(message);
        while (!Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) //check if email contains '@' and '.'
        {
            Console.WriteLine("❌ Invalid email format. Please enter a valid email.");
            input = Prompt(message);
        }   
        return input;
    }
}


/*day 2 coding c# basics C# 

Variables & Data Types

Basic Input/Output

If-Else conditions

Loops (for, while)*/


using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== User Info Program ===\n(Type 'exit' anytime to quit)\n");

        //check ur enters valid name or characters only
        string name = GetValidString("Enter Ur Name :");


        //check ur enters valid age or numbers only
        int age = GetValidInt("Enter Ur Age :");

        //check ur enters valid height or float only
        float height =GetValidFloat("Enter Valid Height :") ;

        //check ur enters valid city name or characters only
        string City = GetValidString("Enter Ur City :");
        
       

        if (age > 25)
        {
            Console.WriteLine("since ur age is " + age + "ur are elible to job");
        }
        else
        {
            Console.WriteLine("since ur age is " + age + "ur are not elible to job");
        }

        //for loop to count and exit

        for (int i = 1; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("exiting...");
    }

    static string Prompt(string message)
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

    //method that return the string and check only characters are entered
    static string GetValidString(string message)
    {
        string input = Prompt(message);
        while(int.TryParse(input,out _))
        {
            Console.WriteLine("Invalid  Enter only letters");
            input = Prompt(message);
        }
        return input;
    }
    //method that return the int and check only numbers are entered
    static int GetValidInt(string message)
    {
        int number ;
        while(!int.TryParse(Prompt(message),out number))
        {
            Console.WriteLine("Invalid  Enter only numbers");
        }
        return number;
    }

    //method that return the float  and check only float are entered

    static float GetValidFloat(string message)
    {
        float number;
        while (!float.TryParse(Prompt(message), out number))
        {
            Console.WriteLine("Invalid  Enter only numbers");
        }
        return number;
    }
}


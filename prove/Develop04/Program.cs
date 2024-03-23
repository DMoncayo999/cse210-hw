using System;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Welcome to Mindfulness App!");

       while(true)
       {
            DisplayMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    Console.WriteLine("Exiting the program");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press Enter to turn to the menu.");
            Console.ReadLine();
            Console.Clear();
       }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
        Console.Write("Select a choice from the menu.");
    }
}
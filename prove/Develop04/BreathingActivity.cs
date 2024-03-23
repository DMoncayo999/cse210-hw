using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "\nThis activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        Console.Clear(); // Clear the console before starting the activity
        Console.WriteLine($"Welcome to {_name} Activity!");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, do you want to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(2);


        Console.Write("Breath in....");
        ShowCountDown(5);

        Console.Write("\nNow breath out....");
        ShowCountDown(5);

        DisplayEndingMessage();
    }
}


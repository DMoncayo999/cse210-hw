using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "\nThis activity involves listing as many positive things as you can think of in a specific area of your life.";
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.Write("\nHow long, in seconds, do you want to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);

        GetRandomPrompt();
        Console.Write("\nYou may begin in: ");

        // Countdown before listing starts
        ShowCountDown(3); 

        Console.Write("\nStart writing your list, type done to finish.");
        List<string> itemList = GetListFromUser();
        _count = itemList.Count;

        Console.WriteLine($"\nYou listed {_count} items.");
        DisplayEndingMessage();

    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine("\nList as many responses you can to the following prompt: "); 
        Console.WriteLine($"\n--- {_prompts[index]} ---");
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        string input;
        do
       {
            input = Console.ReadLine();
            if (input != "done")
            {
                _count++;
            }
        } while (input != "done");

        return _prompts;
    }
}
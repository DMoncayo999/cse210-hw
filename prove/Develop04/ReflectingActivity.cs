using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "\nThis activity involves reflecting deeply on a past experience. Think about a time when you were successful or demonstrated strength.";
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "> Why was this experience meaningful to you?",
            "> Have you ever done anything like this before?",
            "> How did you get started?",
            "> How did you feel when it was complete?",
            "> What made this time different than other times when you were not as successful?",
            "> What is your favorite thing about this experience?",
            "> What could you learn from this experience that applies to other situations?",
            "> What did you learn about yourself through this experience?",
            "> How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        Console.Clear(); 
        DisplayStartingMessage();
        Console.Write("\nHow long, in seconds, do you want to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(2);
        
        DisplayPrompt();

        // Wait for user to press Enter before displaying questions
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();
    
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in:  ");

        // Countdown before questions start
        ShowCountDown(3); 

        Console.Clear();
        DisplayQuestions(3);
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Thread.Sleep(3000); // Pause for 3 seconds after displaying the prompt
    }

   public void DisplayQuestions(int numberOfQuestionsToShow)
{
    Random random = new Random();
    HashSet<int> indexesShown = new HashSet<int>(); // To ensure we don't repeat questions
    int questionsCount = _questions.Count;
    
    // Loop until we show the desired number of questions
    while (indexesShown.Count < numberOfQuestionsToShow)
    {
        int randomIndex = random.Next(questionsCount); // Generate random index
        if (!indexesShown.Contains(randomIndex))
        {
            Console.Write($"\n{_questions[randomIndex]} ");
            ShowSpinner(5); // Show spinner for 5 seconds
            indexesShown.Add(randomIndex); // Add index to the set to avoid repetition
        }
    }
}
}
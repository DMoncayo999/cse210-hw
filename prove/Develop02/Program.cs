using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        // Menu for the user
        Console.WriteLine("Welcome to the Journal Program!");

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select one of the following options: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    LoadJournal(journal);
                    break;
                case "4":
                    SaveJournal(journal);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

    }
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine("Prompt: " + prompt);
        string response = Console.ReadLine();
        Entry newEntry = new Entry(prompt, response, DateTime.Now);
        journal.AddEntry(newEntry);
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save journal(without extension): ");
        string saveFile = Console.ReadLine();

        // If the user doesn't provide a filename, use the default 
        if (string.IsNullOrWhiteSpace(saveFile))
        {
            saveFile = "remember";
        }

        // Append .json extension
        saveFile += ".json";

        journal.SaveToFile(saveFile);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load journal(without extension): ");
        string loadFile = Console.ReadLine();

        // If the user doesn't provide a filename, use the default 
        if (string.IsNullOrWhiteSpace(loadFile))
        {
            loadFile = "remember";
        }

        // Append .json extension
        loadFile += ".json";

        journal.LoadFromFile(loadFile);
    }
}

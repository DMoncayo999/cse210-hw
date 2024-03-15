using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a collection of scripture texts with their references
        Dictionary<string, string> scriptures = new Dictionary<string, string>
        {
            { "John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life." },
            { "Philippians 4:13", "I can do all things through Christ who strengthens me." },
            { "Psalm 23:1", "The Lord is my shepherd; I shall not want." }

        };

        bool running = true;

        while (running)
        {
            // Prompt the user to select a scripture
            Console.WriteLine("Choose a scripture:");
            foreach (var item in scriptures)
            {
                Console.WriteLine($"- {item.Key}");
            }
            Console.WriteLine("Type the reference (e.g., 'John 3:16') or 'quit' to finish:");

            // variable to store the input the user provides
            string selectedScripture = Console.ReadLine();

            if (selectedScripture.ToLower() == "quit")
            {
                running = false;
                continue;
            }

            // Check if the selected scripture exists in the collection
            if (scriptures.ContainsKey(selectedScripture))
            {
                string scriptureText = scriptures[selectedScripture];
                string[] referenceParts = selectedScripture.Split(' '); 

                // Extract book, chapter, and verse information from the selected scripture reference
                string book = referenceParts[0];
                string[] chapterVerse = referenceParts[1].Split(':');
                int chapter = int.Parse(chapterVerse[0]);
                int verse = int.Parse(chapterVerse[1]);

                // Create a scripture with the selected reference and text
                Reference reference = new Reference(book, chapter, verse);
                Scripture scripture = new Scripture(reference, scriptureText);

                // Display reference and scripture text without hidden words
                Console.WriteLine(reference.GetDisplayText());
                Console.WriteLine(scripture.GetDisplayText());

                while (true)
                {
                    Console.WriteLine("Press Enter to continue or type 'quit' to choose another scripture");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                    {
                        break;
                    }

                    // Hide random words
                    scripture.HideRandomWords(5);

                    // Clear the console and reprint the reference and updated scripture text
                    Console.Clear();
                    Console.WriteLine(reference.GetDisplayText());
                    Console.WriteLine(scripture.GetDisplayText());

                    // Check if all words are hidden
                    if (scripture.IsCompletelyHidden())
                    {
                        Console.WriteLine("All words are hidden. Choose another scripture or type 'quit' to finish.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid scripture reference. Please try again.");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
{
    try
    {
        // Serialize the entries to JSON with IncludeFields option enabled
        string json = JsonSerializer.Serialize(_entries);


        // Write the JSON to a file with .json extension
        File.WriteAllText(filename + ".json", json);

        Console.WriteLine("Journal saved successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving journal: {ex.Message}");
    }
}

     public void LoadFromFile(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                // Deserialize JSON with IncludeFields option enabled
                string json = File.ReadAllText(filename);
                _entries = JsonSerializer.Deserialize<List<Entry>>(json);

                Console.WriteLine("Journal loaded successfully.");
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

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
        using (StreamWriter outputFile = new StreamWriter(filename))
    {
        foreach (Entry entry in _entries)
        {
            outputFile.WriteLine($"{entry._promptText},{entry._entryText},{entry._date}");
        }
    }
    Console.WriteLine("Journal saved successfully.");
    
    }

    public void LoadFromFile (string filename)
    {
        if (!File.Exists(filename))
        {
        Console.WriteLine("File does not exist.");
        return;
        }

        _entries.Clear(); // Clear existing entries

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string prompt = parts[0];
            string response = parts[1];
            DateTime date = DateTime.Parse(parts[2]);
            Entry entry = new Entry(prompt, response, date);
            _entries.Add(entry);
        }

        Console.WriteLine("Journal loaded successfully.");

    }

}

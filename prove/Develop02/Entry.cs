using System;

public class Entry
{   
    public string _promptText {get; set;}
    public string _entryText {get; set;}
    public DateTime _date {get; set;}

    // Parameterless constructor required for deserialization
    public Entry()
    {

    }

    //Constructor for initializing Entry object
    public Entry(string promptText, string entryText, DateTime date)
    {
        _promptText = promptText;
        _entryText = entryText;
        _date = date;

    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date}, Prompt: {_promptText} {_entryText}");

    }

}
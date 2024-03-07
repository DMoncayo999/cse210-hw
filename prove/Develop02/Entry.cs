using System;

public class Entry
{   
    public string _promptText;
    public string _entryText;
    public DateTime _date;

    //Constructor
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
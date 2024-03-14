using System;
using System.Data;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    //constructor to initialize a Reference object with a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse; // Set endVerse to the same value as verse
    }

    //constructor to initialize a Reference object with a range of verse
    public Reference(string book, int chapter, int starVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = starVerse;
        _endVerse = endVerse;

    }

    // Method to get the display text of the reference
    public string GetDisplayText()
    {
        if (_verse == _endVerse)
            return $"{_book} {_chapter}: {_verse}";
        else
            return $"{_book} {_chapter}: {_verse} - {_endVerse}";
    }

}
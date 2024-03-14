using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    //
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // By default, the word is not hidden when created 
    }

    // Method to hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Method to show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Method to check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // method to get the display text of the word, showing underscores if hidden
    public string GetDisplayText()
    {
        return _isHidden ? "___": _text;
    }

}
using System;

public class Shape 
{
    private string _color;

    // Constructor
    public Shape (string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Setter for color
    public void SetColor(string color)
    {
        _color = color;
    }
    // Virtual method for calculating area
    public virtual double GetArea()
    {
        return 0; // Default implementation, to be overridden in derived classes
    }

}

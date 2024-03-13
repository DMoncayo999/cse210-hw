using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor that initializes the fraction to 1/1
    public Fraction()
    {
        _top = 1 ;
        _bottom = 1; 

    }
    // Constructor that initializes the fraction with a whole number
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor that initializes the fraction with givem numerator and denominator
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for the numerator
    public int GetTop()
    {
        return _top;
    }

    // Setter for the numerator
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for the denominator
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for the denominator
    public void SetBottom(int bottom)
    {
        _bottom = bottom;

    }

    // Method to return the fraction representation as a string (e.g.3/4)
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
   
}
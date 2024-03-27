using System;

public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor
    public Rectangle(string color, double lengh, double with) : base(color)
    {
       _length = lengh;
       _width = with;
    }

    // Override GetArea method to calculate rectangle's area 
    public override double GetArea()
    {
        return _length * _width;  
    }
}

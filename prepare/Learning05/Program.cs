using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes

        List<Shape> shapes = new List<Shape>();

        // Add instances of Square, Rectangle and circle to the list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4 , 6));
        shapes.Add(new Circle("Green", 3));

        // Iterate through the list of shapes
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}.");
            
        }
    }
}
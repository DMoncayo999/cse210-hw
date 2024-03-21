using System;

class Program
{
    static void Main(string[] args)
    {
         // Create a math assignment
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");

        // Display the summary
        Console.WriteLine(mathAssignment.GetSummary());

        // Display the homework list
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Create a writing assignment
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");

        // Display the writing information
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}
using System;

// Class MathAssignment inherits from base Assignment class
public class MathAssignment : Assignment
{
    // Class attributes as private member variables
    private string _textbookSection;
    private string _problems;

    // Constructor that accepts all 4 parameters, to set base class attributes 

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
    : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;

    }

    // Method 
    public string GetHomeworkList()
    {
        return $"Section: {_textbookSection} Problems: {_problems}";
    }

}
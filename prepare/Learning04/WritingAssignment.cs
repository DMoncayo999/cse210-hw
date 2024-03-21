using System;

// Class WritingAssignment inheritans from base Assignment class 
public class WritingAssignment : Assignment
{
    // Member variables
    private string _title;

    // Constructor  to set base class attributes 

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }
    
    // Method GetWritingInformation()
     public string GetWritingInformation()
     {

        return $"{_studentName} - {_topic}  {_title}";
     }
   
}
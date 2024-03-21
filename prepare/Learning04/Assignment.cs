using System;

public class Assignment {

    //Private mmember variables
    protected string _studentName;
    protected string _topic;


    //Constructor with student name and topic atributes

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }


    // Method to return the student's name and the topic
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
        
}
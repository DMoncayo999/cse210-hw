using System;
using System.Collections.Generic;
using System.IO;

// Derived class for simple goals
public class SimpleGoal : Goal
{
    private bool _isComplete;
    
    // Cosntructor

   public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
    _isComplete = isComplete;
    }

    // Methods
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Recorded event for SimpleGoal: {_shortName}");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal: {_shortName}, {_description}, {_points}, {_isComplete}";
    }
}
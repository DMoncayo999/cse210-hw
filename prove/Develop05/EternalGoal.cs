using System;
using System.Collections.Generic;
using System.IO;

// Derived class for eternal goals
public class EternalGoal : Goal
{
    // No attributes

    //Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No specific initialization needed for eternal goals
    }

    // Methods
    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for EternalGoal: {_shortName}");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetStringRepresentation()
    {
    return $"EternalGoal: {_shortName}, {_description}, {_points}";
    }
}

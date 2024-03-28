using System;
using System.Collections.Generic;
using System.IO;

// Base class for all types of goals
public abstract class Goal
 {
    public string _shortName;
    public string _description;
    public int _points;

    // Constructor
    public Goal(string name, string description, int points) 
    {
       _shortName = name;
       _description = description;
       _points = points;
    }

    // Methods
    public abstract void RecordEvent();

    public abstract bool IsComplete();

   public virtual string GetDetailsString()
    {
        return $"{_shortName}: {_description} ({_points} points)";
    }
    public abstract string GetStringRepresentation();
}
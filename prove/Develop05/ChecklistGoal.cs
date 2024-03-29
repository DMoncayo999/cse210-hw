using System;
using System.Collections.Generic;
using System.IO;

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    public int _amountCompleted;
    public int _target;
    public int _bonus;

    // Constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus, bool isComplete) : base(name, description, points)
    {
    _amountCompleted = isComplete ? target : 0; // Assuming if isComplete is true, set amountCompleted to target
    _target = target;
    _bonus = bonus;
    }
    // Methods
    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Record event for ChecklistGoal: {_shortName}");
   
    if (_amountCompleted >= _target)
    {
        _points += _bonus; // apply bonus if target is reached
        Console.WriteLine($"Congratulations! You've completed {_shortName} and received a bonus of {_bonus} points.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string completionStatus = IsComplete() ? $"Completed {_amountCompleted}/{_target} times" : $"Incomplete {_amountCompleted}/{_target} times";
        return $"{_shortName}: {_description} ({_points} points, {completionStatus})";
    }

    public override string GetStringRepresentation()
    {
         return $"ChecklistGoal: {_shortName}, {_description}, {_points}, {_amountCompleted}, {_target}, {_bonus}";
    }
}


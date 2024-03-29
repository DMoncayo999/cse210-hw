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
        _amountCompleted = isComplete ? target : 0; // If isComplete is true, set amountCompleted to target
        _target = target;
        _bonus = bonus;
    }

    // Methods
    public override void RecordEvent()
    {
        if (!IsComplete())  // Check if the goal is not yet complete
        {
            _amountCompleted++;  // Increment the number of times the goal has been completed

            if (IsComplete())  // Check if the goal is now complete after incrementing
            {
                _points += _bonus;  // Apply the bonus points since the target is reached
                Console.WriteLine($"Congratulations! You've completed {_shortName} and received a bonus of {_bonus} points.");
            }

            Console.WriteLine($"Record event for ChecklistGoal: {_shortName}");
        }
        else
        {
            Console.WriteLine($"The goal {_shortName} has already been completed {_amountCompleted}/{_target} times.");
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
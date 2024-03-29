using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    
    // Methods
        public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have: {_score} points");
    }
    
    public void Start()
    {
        DisplayPlayerInfo();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The Types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        // Logic to create a new goal based on the selected type
        switch (choice)
        {
            case 1:
                CreateSimpleGoal();
                break;
            case 2:
                CreateEternalGoal();
                break;
            case 3:
                CreateChecklistGoal();
                break;
        }
    }

    private void CreateSimpleGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        if (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        // Create and add the simple goal to the list
        SimpleGoal goal = new SimpleGoal(name, description, points, false);
        _goals.Add(goal);
    }

    private void CreateEternalGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        if (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        // Create and add the eternal goal to the list
        EternalGoal goal = new EternalGoal(name, description, points);
        _goals.Add(goal);
    }

    private void CreateChecklistGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        if (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        Console.Write("How many times that this goal need to be acomplish for a bonus? ");
        int target;
        if (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
        {
            Console.WriteLine("Invalid target value.");
            return;
        }

        Console.Write("What is the bonus for acomplishig it that many times? ");
        int bonus;
        if (!int.TryParse(Console.ReadLine(), out bonus) || bonus <= 0)
        {
            Console.WriteLine("Invalid bonus value.");
            return;
        }

        // Create and add the checklist goal to the list
        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus, false);
        _goals.Add(goal);
}

    public void RecordEvent()
    {
        Console.WriteLine("\nRecording an event:");

        ListGoalDetails();

        Console.Write("Enter the name of the goal to record event for: ");
        string goalName = Console.ReadLine();

        RecordEvent(goalName);
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = _goals.Find(g => g._shortName == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            _score += goal._points;
            Console.WriteLine($"Event recorded for {goalName}. You gained {goal._points} points.");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }
    public void ListGoalDetails()
{
    Console.WriteLine("Goals:");

    if (_goals.Count == 0)
    {
        Console.WriteLine("No goals available."); // Display message if no goals are available
        return;
    }

    // Display goals if available
    for (int i = 0; i < _goals.Count; i++)
    {
        string checkbox = _goals[i].IsComplete() ? "[X]" : "[ ]";
        string goalInfo = $"{i + 1}. {checkbox} {_goals[i]._shortName.Trim()} ({_goals[i]._description.Trim()})";

        if (_goals[i] is ChecklistGoal checklistGoal)
        {
            string completedStatus = $" --- Currently completed: {checklistGoal._amountCompleted}/{checklistGoal._target}";
            goalInfo += completedStatus.PadLeft(Math.Max(0, 35 - goalInfo.Length)); // Adjust the spacing as needed
        }

        Console.WriteLine(goalInfo);
    }
}

    public void SaveGoals()
    {
        Console.Write("Enter file path to save goals: ");
        string filePath = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    
   public void LoadGoals()
    {
        Console.Write("Enter file path to load goals from: ");
        string filePath = Console.ReadLine();

        try
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                if (parts.Length >= 2)
                {
                    string type = parts[0];
                    string details = parts[1];

                    // Call the CreateGoalFromString method to create the appropriate goal
                    Goal goal = CreateGoalFromString(type, details);

                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                    else
                    {
                        Console.WriteLine($"Unknown goal type: {type}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid line format: {line}");
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private Goal CreateGoalFromString(string type, string details)
{
    string[] parts = details.Split(',');

    if (parts.Length < 3)
    {
        Console.WriteLine($"Invalid details format for goal: {details}");
        return null;
    }

    string name = parts[0].Trim();
    string description = parts[1].Trim();
    int points;
    if (!int.TryParse(parts[2].Trim(), out points))
    {
        Console.WriteLine($"Invalid points format for goal: {details}");
        return null;
    }

    // Check if type is EternalGoal
    if (type == "EternalGoal")
    {
        return new EternalGoal(name, description, points);
    }

    // Handle other goal types if needed
    switch (type)
    {
        case "SimpleGoal":
            bool isComplete = parts[3].Trim().Equals("True", StringComparison.OrdinalIgnoreCase); // Convert string to boolean
            return new SimpleGoal(name, description, points, isComplete);

        case "ChecklistGoal":
            int target;
            if (!int.TryParse(parts[3].Trim(), out target))
            {
                Console.WriteLine($"Invalid target format for goal: {details}");
                return null;
            }
            int bonus;
            if (!int.TryParse(parts[4].Trim(), out bonus))
            {
                Console.WriteLine($"Invalid bonus format for goal: {details}");
                return null;
            }
            bool isGoalComplete = parts[5].Trim().Equals("True", StringComparison.OrdinalIgnoreCase); // Convert string to boolean
            return new ChecklistGoal(name, description, points, target, bonus, isGoalComplete);

        default:
            Console.WriteLine($"Unknown goal type: {type}");
            return null; // Add a default return statement
      }
   }
}
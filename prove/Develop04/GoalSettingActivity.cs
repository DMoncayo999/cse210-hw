using System;

public class GoalSettingActivity : Activity
{
    private string _area;

    public GoalSettingActivity(string area)
    {
        _name = "Goal Setting";
        _description = "\nThis activity will guide you through setting SMART goals in a specific area of your life.";
        _area = area;
    }

    public void Run()
    {
        Console.Clear(); // Clear the console before starting the activity
        DisplayStartingMessage();
        Console.Write("\nHow long, in seconds, do you want to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Write("\nEnter the area where you want to set a goal (e.g., health, career, relationships, etc.): ");
        _area = Console.ReadLine();

        Console.WriteLine($"\nGet ready to start setting a SMART goal for {_area}:");
        ShowSpinner(2);
        string goal = GetGoalFromUser();
        

        Console.WriteLine($"\nGreat! Your SMART goal for {_area} is:");
        Console.WriteLine(goal);

        DisplayEndingMessage();
    }

    public string GetGoalFromUser()
    {
        Console.WriteLine("Specific: What exactly do you want to achieve?");
        string specific = Console.ReadLine();

        Console.WriteLine("Measurable: How will you measure your progress?");
        string measurable = Console.ReadLine();

        Console.WriteLine("Achievable: Is your goal realistic and attainable?");
        string achievable = Console.ReadLine();

        Console.WriteLine("Relevant: Does this goal align with your values and priorities?");
        string relevant = Console.ReadLine();

        Console.WriteLine("Time-bound: What is your deadline for achieving this goal?");
        string timeBound = Console.ReadLine();

        return $"SMART Goal for {_area}:\n- Specific: {specific}\n- Measurable: {measurable}\n- Achievable: {achievable}\n- Relevant: {relevant}\n- Time-bound: {timeBound}";
    }
}
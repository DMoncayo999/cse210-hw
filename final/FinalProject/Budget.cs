using System;

public class Budget
{
    private string _name;
    private decimal _totalAmount;
    private DateTime _startDate;
    private DateTime _endDate;

    // Constructor
    public Budget(string name, decimal totalAmount, DateTime startDate, DateTime endDate)
    {
        _name = name;
        _totalAmount = totalAmount;
        _startDate = startDate;
        _endDate = endDate;
    }

    // Calculate remaining budget amount
    public decimal CalculateRemainingBudget()
    {
        // Logic to calculate remaining budget based on expenses/incomes
        decimal remainingBudget = _totalAmount - CalculateTotalExpenses();
        return remainingBudget;
    }

    // Calculate total expenses within budget period
    private decimal CalculateTotalExpenses()
    {
        // Logic to calculate total expenses from expenses data within budget period
        decimal totalExpenses = 0;  // Placeholder, replace with actual calculation
        return totalExpenses;
    }

    // Generate budget report
    public string GenerateBudgetReport()
    {
        // Generate and return a report with budget details, utilization, remaining amount, etc.
        string report = $"Budget Name: {_name}\n" +
                        $"Total Budget Amount: {_totalAmount:C}\n" +
                        $"Start Date: {_startDate.ToShortDateString()}\n" +
                        $"End Date: {_endDate.ToShortDateString()}\n" +
                        $"Remaining Budget: {CalculateRemainingBudget():C}\n";

        // Add more information as needed

        return report;
    }
}
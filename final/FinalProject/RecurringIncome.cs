using System;

public class RecurringIncome : Income
{
    protected string _recurrence;

    // Constructor for RecurringIncome
    public RecurringIncome(string description, decimal amount, DateTime date, string category, bool isIncome, string frequency, string recurrence)
        : base(description, amount, date, category, isIncome, frequency)
    {
        _recurrence = recurrence;
    }

    // Method to get the recurrence
    public string GetRecurrence()
    {
        return _recurrence;
    }

    // Method to set the recurrence
    public void SetRecurrence(string recurrence)
    {
        _recurrence = recurrence;
    }
    // Method to add recurring income
    public void AddRecurringIncome(decimal amount)
    {
        _amount += amount;
    }
}
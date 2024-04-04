using System;

public class FixedExpense : Expense
{
    protected bool _recurring;

    // Constructor for FixedExpense
    public FixedExpense(string description, decimal amount, DateTime date, string category, bool isIncome, bool recurring)
        : base(description, amount, date, category, isIncome)
    {
        _recurring = recurring;
    }

    // Method to get the recurring status
    public bool GetRecurring()
    {
        return _recurring;
    }

    // Method to set the recurring status
    public void SetRecurring(bool recurring)
    {
        _recurring = recurring;
    }

    // Method to add a fixed expense
    public void AddFixedExpense(decimal amount)
    {
        _amount += amount;
    }
}
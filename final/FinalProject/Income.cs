using System;

public class Income : Expense
{
    protected string _frequency;

    // Constructor for Income
    public Income(string description, decimal amount, DateTime date, string category, bool isIncome, string frequency)
        : base(description, amount, date, category, isIncome)
    {
        _frequency = frequency;
    }

    // Method to get the frequency
    public string GetFrequency()
    {
        return _frequency;
    }

    // Method to set the frequency
    public void SetFrequency(string frequency)
    {
        _frequency = frequency;
    }
    
    // Method to add income
    public void AddIncome(decimal amount)
    {
        _amount += amount;
    } 

}
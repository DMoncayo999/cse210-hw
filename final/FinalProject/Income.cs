using System;
using System.Globalization;

public class Income : Expense
{
    protected string _frequency;

    // Constructor for Income
    public Income(string description, decimal amount, DateTime date, string category, bool isIncome, string frequency)
        : base(description, amount, date, category, isIncome)
    {
        _frequency = frequency;
    }

    // Getter for Frequency
    public string Frequency
    {
        get { return _frequency; }
        set { _frequency = value; }
    }

    // Method to add income
    public void AddIncome(decimal amount)
    {
        _amount += amount;
    }

}
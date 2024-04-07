using System;
using System.Collections.Generic;

public class Expense
{
    protected string _description;
    protected decimal _amount;
    protected DateTime _date;
    protected string _category;
    protected bool _isIncome;

    // Constructor following naming conventions
    public Expense(string description, decimal amount, DateTime date, string category, bool isIncome)
    {
        _description = description;  
        _amount = amount;  
        _date = date;  
        _category = category;  
        _isIncome = isIncome;  
    }
     public void AddExpense(decimal amount)
    {
        _amount += amount;
    }

    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public string FormatExpenseForDisplay()
    {
        return $"Description: {_description}\nAmount: {_amount:C}\nDate: {_date.ToShortDateString()}\nCategory: {_category}\nIs Income: {_isIncome}";
    }

    public static decimal CalculateTotalExpenses(List<Expense> expenses)
    {
        decimal total = 0;
        foreach (Expense expense in expenses)
        {
            total += expense.Amount;
        }
        return total;
    }

    public static List<Expense> FilterExpensesByDateRange(List<Expense> expenses, DateTime startDate, DateTime endDate)
    {
        List<Expense> filteredExpenses = new List<Expense>();
        foreach (Expense expense in expenses)
        {
            if (expense._date >= startDate && expense._date <= endDate)
            {
                filteredExpenses.Add(expense);
            }
        }
        return filteredExpenses;
    }

    public static void SortExpensesByAmount(List<Expense> expenses)
    {
        expenses.Sort((x, y) => x._amount.CompareTo(y._amount));
    }
}
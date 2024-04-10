using System;
using System.Collections.Generic;
using System.Globalization;

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
    
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public decimal Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    } 

     public string Category
    {
        get { return _category; }
        set { _category = value; }
    }

    public bool IsIncome
    {
        get { return _isIncome; }
        set { _isIncome = value; }
    }
   
     public void AddExpense(decimal amount)
    {
        _amount += amount;
    }
}
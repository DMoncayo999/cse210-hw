using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
public class Category
{
    private string _name;
    private string _description;

    public Category(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }
}
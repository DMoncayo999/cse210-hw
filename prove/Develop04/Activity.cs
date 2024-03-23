using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
    
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name} activity.");
        ShowSpinner(2);
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/\b");
            Thread.Sleep(250);
            Console.Write("|\b");
            Thread.Sleep(250);
            Console.Write("\\\b");
            Thread.Sleep(250);
            Console.Write("-\b");
            Thread.Sleep(250);
            
        }
    }

   public void ShowCountDown(int seconds)
    {
    for (int i = seconds; i > 0; i--)
    {
        Console.Write(i);
        Thread.Sleep(1000); 
        Console.Write("\b \b"); 
    }
  }
}
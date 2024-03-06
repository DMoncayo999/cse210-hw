using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job>_jobs;

    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();
    }

 public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }

}




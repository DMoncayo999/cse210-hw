using System;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    private string _fileName;

    public FileManager(string fileName)
    {
        _fileName = fileName;
    }

    public List<string[]> ReadFromFile()
    {
        List<string[]> data = new List<string[]>();

        try
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    data.Add(values);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }

        return data;
    }

    public void WriteToFile(List<string[]> data)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                foreach (string[] values in data)
                {
                    string line = string.Join(",", values);
                    writer.WriteLine(line);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }

    // Save report to file
    public void SaveReport(string reportContent)
    {
    try
        {
            using (StreamWriter writer = new StreamWriter(_fileName, true)) // Append content to the existing file
            {
                writer.WriteLine(reportContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving report: " + ex.Message);
        }
    }

    // Load report from file
    public string LoadReport()
    {
        try
        {
            if (File.Exists(_fileName))
            {
                return File.ReadAllText(_fileName);
            }
            else
            {
                return "No data available.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading report: " + ex.Message);
            return "Error loading report.";
        }
    }
}
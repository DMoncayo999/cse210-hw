using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class FileManager
{
    private string _filePath;

    public FileManager(string filePath)
    {
        _filePath = filePath;
    }

    public List<string[]> ReadFromFile()
    {
        List<string[]> data = new List<string[]>();

        try
        {
            using (StreamReader reader = new StreamReader(_filePath))
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
            using (StreamWriter writer = new StreamWriter(_filePath))
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
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(reportContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving report: " + ex.Message);
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        Console.Write("Enter number: ");

        int number = int.Parse(Console.ReadLine());
        while (number != 0)
        {
            numbers.Add(number);

            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int maxNum = numbers.Max();

        Console.WriteLine($"The total sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNum}");
    }
}
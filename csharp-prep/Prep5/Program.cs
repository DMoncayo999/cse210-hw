using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        Console.WriteLine($"Hello, {name}!");

        int number = PrompUserNumber();
        Console.WriteLine($"Your favorite number is {number}");

        int square = SquareNumber(number);

        DisplayResult(name, square);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }
    static int PrompUserNumber()
    {
        Console.Write("What is your favorite number? ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquareNumber(int num)
    {
        return num * num;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {square}");

    }

}
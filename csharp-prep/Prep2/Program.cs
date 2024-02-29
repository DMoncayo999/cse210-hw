using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userAnswer = Console.ReadLine();
        int percentage = int.Parse(userAnswer);

        char letter;

        if (percentage >= 90)
        {
            letter = 'A';
        }
        else if (percentage >= 80)
        {
            letter = 'B';
        }
        else if (percentage >= 70)
        {
            letter = 'C';
        }
        else if (percentage >= 60)
        {
            letter = 'D';
        }
        else 
        {
            letter = 'F';
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (percentage >= 70)
        {
            Console.WriteLine("Great! You passed the course");
        }
        else
        {
            Console.WriteLine("Don't give up, next time you will do better!" );
        }        

    }
}
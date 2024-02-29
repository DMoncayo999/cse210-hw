using System;

class Program
{
    static void Main(string[] args)
    {
       // Console.Write("What is the magic number? ");
       // int answer = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int answer = randomGenerator.Next(1, 101);

        int guess = 0;

        while (guess != answer)
        {
            Console.Write("What is your guest? ");
            guess = int.Parse(Console.ReadLine());

            if (answer > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (answer < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.Write("Yeah, you guessed it!");

            }
        }

    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
       // Create the first job instance
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
       // Create the second job instance 
        Job job2 = new Job("Apple", "Product Manager", 2022, 2023);

         // Create a resume instance
        Resume myResume = new Resume("Allison Rose");

        // Add the jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the resume details
        myResume.Display();

        // Access and display the first job title from the resume
        //Console.WriteLine($"First Job Title: {myResume._jobs[0]._jobTitle}");

        // Call the Display method for each job instance
        //job1.Display();
        //job2.Display();
    }
}
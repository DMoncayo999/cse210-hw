using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        // Loop until the user chooses to exit
        while (!exit)
        {
            Console.WriteLine("=== Expenses Tracker Menu ===");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. Add Income");
            Console.WriteLine("3. Add Fixed Expense");
            Console.WriteLine("4. Add Recurring Income");
            Console.WriteLine("5. View Categories");
            Console.WriteLine("6. View Budgets");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // AddExpense functionality
                    Console.WriteLine("Adding Expense...");
                    break;
                case "2":
                    // AddIncome functionality
                    Console.WriteLine("Adding Income...");
                    break;
                case "3":
                    // AddFixedExpense functionality
                    Console.WriteLine("Adding Fixed Expense...");
                    break;
                case "4":
                    // AddRecurringIncome functionality
                    Console.WriteLine("Adding Recurring Income...");
                    break;
                case "5":
                    // ViewCategories functionality
                    Console.WriteLine("Viewing Categories...");
                    break;
                case "6":
                    // ViewBudgets functionality
                    Console.WriteLine("Viewing Budgets...");
                    break;
                case "7":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            // Add a pause after each action for readability
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear(); // Clear the console for the next menu display
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Initialize an empty list to store expenses
        List<Expense> expenses = new List<Expense>(); 
        List<Category> categories = new List<Category>();
        List<Budget> budgets = new List<Budget>();

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
                    AddExpense(expenses);
                    break;
                case "2":
                    // AddIncome functionality
                    AddIncome(expenses);
                    break;
                case "3":
                    // AddFixedExpense functionality
                    AddFixedExpense(expenses);
                    break;
                case "4":
                    // AddRecurringIncome functionality
                    AddRecurringIncome(expenses);
                    break;
                case "5":
                    // ViewCategories functionality
                    ViewCategories(categories);
                    break;
                case "6":
                    // ViewBudgets functionality
                    ViewBudgets(budgets);
                    break;
                case "7":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear(); // Clear the console for the next menu display
        }
    }

    static void AddExpense(List<Expense> expenses)
    {
        Console.WriteLine("Enter expense details:");
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Amount: ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            Console.Write("Amount: ");
        }
        Console.Write("Date (MM/dd/yyyy): ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date in MM/dd/yyyy format.");
            Console.Write("Date (MM/dd/yyyy): ");
        }
        Console.Write("Category: ");
        string category = Console.ReadLine();
        Console.Write("Is Income (true/false): ");
        bool isIncome;
        while (!bool.TryParse(Console.ReadLine(), out isIncome))
        {
            Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
            Console.Write("Is Income (true/false): ");
        }

        // Create new Expense object and add it to the list
        Expense newExpense = new Expense(description, amount, date, category, isIncome);
        expenses.Add(newExpense);

        Console.WriteLine("Expense added successfully!");
    }

    static void AddIncome(List<Expense> expenses)
    {
    Console.WriteLine("Enter income details:");
    Console.Write("Description: ");
    string description = Console.ReadLine();
    Console.Write("Amount: ");
    decimal amount = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Date (MM/dd/yyyy): ");
    DateTime date = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Category: ");
    string category = Console.ReadLine(); // Add category input
    Console.Write("Frequency: ");
    string frequency = Console.ReadLine();

    // set isIncome to true
    bool isIncome = true;

    // new Income object and add it to the list
    Income newIncome = new Income(description, amount, date, category, isIncome, frequency);
    expenses.Add(newIncome);

    Console.WriteLine("Income added successfully!");
    }

    static void AddFixedExpense(List<Expense> expenses)
    {
    Console.WriteLine("Enter fixed expense details:");
    Console.Write("Description: ");
    string description = Console.ReadLine();
    Console.Write("Amount: ");
    decimal amount = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Date (MM/dd/yyyy): ");
    DateTime date = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Category: ");
    string category = Console.ReadLine(); // Add category input
    Console.Write("Is Recurring (true/false): ");
    bool isRecurring = Convert.ToBoolean(Console.ReadLine()); // Add isRecurring input

    // Create new FixedExpense object and add it to the list
    FixedExpense newFixedExpense = new FixedExpense(description, amount, date, category, false, isRecurring); // Pass 'false' for the missing 'recurring' parameter
    expenses.Add(newFixedExpense);

    Console.WriteLine("Fixed Expense added successfully!");
    }

    static void AddRecurringIncome(List<Expense> expenses)
    {
    Console.WriteLine("Enter recurring income details:");
    Console.Write("Description: ");
    string description = Console.ReadLine();
    Console.Write("Amount: ");
    decimal amount = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Date (MM/dd/yyyy): ");
    DateTime date = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Category: ");
    string category = Console.ReadLine(); // Add category input
    Console.Write("Is Recurring (true/false): ");
    bool isRecurring = Convert.ToBoolean(Console.ReadLine()); // Add isRecurring input
    Console.Write("Frequency: ");
    string frequency = Console.ReadLine(); // Add frequency input
    Console.Write("Recurrence: ");
    string recurrence = Console.ReadLine(); // Add recurrence input

    // Create new RecurringIncome object and add it to the list
    RecurringIncome newRecurringIncome = new RecurringIncome(description, amount, date, category, false, frequency, recurrence); // Pass 'false' for the missing 'isIncome' parameter
    expenses.Add(newRecurringIncome);

    Console.WriteLine("Recurring Income added successfully!");
    }

   static void ViewCategories(List<Category> categories)
    {
    Console.WriteLine("Viewing Categories:");
    foreach (Category category in categories)
    {        
        Console.WriteLine($"Category Name: {category.GetName()}");
        Console.WriteLine($"Category Description: {category.GetDescription()}");
        Console.WriteLine("--------------------");
    }
    }

    static void ViewBudgets(List<Budget> budgets)
    {
    Console.WriteLine("Viewing Budgets:");
    foreach (Budget budget in budgets)
    {
        
        Console.WriteLine($"Budget Name: {budget.GetName()}");
        Console.WriteLine($"Total Amount: {budget.GetTotalAmount():C}");
        Console.WriteLine($"Start Date: {budget.GetStartDate().ToShortDateString()}");
        Console.WriteLine($"End Date: {budget.GetEndDate().ToShortDateString()}");
        Console.WriteLine("--------------------");
    }
    }
}
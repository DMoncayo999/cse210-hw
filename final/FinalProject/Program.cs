using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Initialize an empty list to store expenses
        List<Expense> expenses = new List<Expense>(); 
        List<Category> categories = new List<Category>();
        List<Budget> budgets = new List<Budget>();

        // Populate categories list with some default categories
        categories.Add(new Category("Food", "Expenses related to food"));
        categories.Add(new Category("Vehicle", "Expenses related to vehicle"));
        categories.Add(new Category("Entertainment", "Expenses related to entertaiment activities"));

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
                    AddExpense(expenses, categories);
                    break;
                case "2":
                    AddIncome(expenses);
                    break;
                case "3":
                    AddFixedExpense(expenses);
                    break;
                case "4":
                    AddRecurringIncome(expenses);
                    break;
                case "5":
                    ViewCategories(categories);
                    break;
                case "6":
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

    // Method to add an expense
    static void AddExpense(List<Expense> expenses, List<Category> categories)
    {
        Console.WriteLine("Select a category:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].GetName()}");
        }

        int categoryIndex;
        while (!int.TryParse(Console.ReadLine(), out categoryIndex) || categoryIndex < 1 || categoryIndex > categories.Count)
        {
            Console.WriteLine("Invalid category selection. Please enter a valid category number.");
            Console.Write("Select a category: ");
        }

        string category = categories[categoryIndex - 1].GetName();

        // Gather input for other expense attributes
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

        // Create new Expense object and add it to the list
        Expense newExpense = new Expense(description, amount, date, category, false);
        expenses.Add(newExpense);

        Console.WriteLine("Expense added successfully!");
    }

    // Method to add Income
    static void AddIncome(List<Expense> expenses)
    {
        Console.WriteLine("Enter income details:");
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Date (MM/dd/yyyy): ");
        DateTime date = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Category: Write if it is Salary/Wages, Investment, Business, Gift, Other: ");
        string category = Console.ReadLine(); 
        Console.Write("Frequency: Write if it is Monthly, Weekly, Biweekly, Yearly: ");
        string frequency = Console.ReadLine();

        // set isIncome to true
        bool isIncome = true;

        // new Income object and add it to the list
        Income newIncome = new Income(description, amount, date, category, isIncome, frequency);
        expenses.Add(newIncome);

        Console.WriteLine("Income added successfully!");
    }


    // Method to add Fixed Expenses
    static void AddFixedExpense(List<Expense> expenses)
    {
        Console.WriteLine("Enter fixed expense details:");
        // Gather input for fixed expense attributes
        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Amount: ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid amount:");
            Console.Write("Amount: ");
        }

        Console.Write("Date (MM/DD/YYYY): ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            Console.WriteLine("Invalid date format. Please enter the date in MM/DD/YYYY format:");
            Console.Write("Date (MM/DD/YYYY): ");
        }

        // Define a list of predefined categories for fixed expenses
        List<string> fixedExpenseCategories = new List<string>
        {
            "Rent/Mortgage",
            "Utilities",
            "Insurance (Health, Car, Homeowners)",
            "Subscriptions (Netflix, Spotify, Gym)",
            "Loan Payments",
            "Taxes (Property Tax, Income Tax)"
        };

        // Display the categories for the user to choose from
    Console.WriteLine("Select a category for Fixed Expense:");
    for (int i = 0; i < fixedExpenseCategories.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {fixedExpenseCategories[i]}");
    }

    int categoryIndex;
    while (!int.TryParse(Console.ReadLine(), out categoryIndex) || categoryIndex < 1 || categoryIndex > fixedExpenseCategories.Count)
    {
        Console.WriteLine("Invalid category selection. Please enter a valid category number.");
        Console.Write("Select a category: ");
    }

    string category = fixedExpenseCategories[categoryIndex - 1];

    // Create a new FixedExpense object and add it to the list
    FixedExpense newFixedExpense = new FixedExpense(description, amount, date, category, false); // Set recurring to false
    expenses.Add(newFixedExpense);

    Console.WriteLine("Fixed Expense added successfully!");
}

    // Method to add Recurring Income
    static void AddRecurringIncome(List<Expense> expenses)
    {
        Console.Write("Description: Enter a description for the recurring income: "); // Prompt for description
        string description = Console.ReadLine(); 

        Console.Write("Category: Please enter the source of your income (e.g., Salary/Wages, Investment, Business, Gift, Other): ");
        string category = Console.ReadLine();

        Console.Write("Amount: Enter the amount of income: ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid amount:");
            Console.Write("Amount: ");
        }

        Console.Write("Date (MM/DD/YYYY): Enter the date of income: ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {   
            Console.WriteLine("Invalid date format. Please enter the date in MM/DD/YYYY format:");
            Console.Write("Date (MM/DD/YYYY): ");
        }

        Console.Write("Frequency: How often do you receive this income (e.g., Monthly, Weekly, Biweekly, Yearly): ");
        string frequency = Console.ReadLine();

        // For recurrence, you can prompt the user for any additional information they need to specify for recurring income
        Console.Write("Recurrence: Provide any additional details about the recurrence of this income: ");
        string recurrence = Console.ReadLine();

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
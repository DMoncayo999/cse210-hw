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

        // Populate categories list with some default categories
        List<Category> categories = new List<Category>();
        categories.Add(new Category("Food", "Expenses related to food"));
        categories.Add(new Category("Vehicle", "Expenses related to vehicle"));
        categories.Add(new Category("Entertainment", "Expenses related to entertaiment activities"));

        // Define a list of predefined categories for fixed expenses
        List<string> fixedExpenseCategories = new List<string>  
        {
            "Rent/Mortgage",
            "Utilities",
            "Insurance",
            "Subscriptions",
            "Loan Payments",
            "Taxes"
        };
          
          
        
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
            Console.WriteLine("7. View Report");
            Console.WriteLine("8. Exit");

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
                    AddFixedExpense(expenses, fixedExpenseCategories);
                    break;
                case "4":
                    AddRecurringIncome(expenses);
                    break;
                case "5":
                    ViewCategories(categories, fixedExpenseCategories);
                    break;
                case "6":
                    ViewReport();
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
        Console.WriteLine("Please enter the category of the expense:");
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

        // Gather input 
        Console.Write("Enter expense description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the amount of the expense: ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            Console.Write("Amount: ");
        }

        Console.Write("Enter the date of the expense: (MM/dd/yyyy): ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date in MM/dd/yyyy format.");
            Console.Write("Date (MM/dd/yyyy): ");
        }        

        // Create new Expense object and add it to the list
        Expense newExpense = new Expense(description, amount, date, category, false);
        expenses.Add(newExpense);

        // Save the entry using FileManager
        FileManager fileManager = new FileManager("report.txt");
        string reportContent = $"Type: Expense, Category: {category}, Description: {description}, Amount: ${amount:N2}, Date: {date.ToString("MM/dd/yyyy")}";
        fileManager.SaveReport(reportContent);

        Console.WriteLine("Expense added successfully and saved to report.txt!");
        
       // Update the view report after adding the new entry
        ViewReport(); 
    }

    // Method to add Income
    static void AddIncome(List<Expense> expenses)
    {
        Console.Write("Enter income description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the amount of the income: ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            Console.Write("Amount: ");
        }

        Console.Write("Enter the date you receive this income: (MM/dd/yyyy): ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date in MM/dd/yyyy format.");
            Console.Write("Date (MM/dd/yyyy): ");
        }

        Console.Write("Write the category of this income. It is Salary/Wages, Investment, Business, Gift, Other: ");
        string category = Console.ReadLine();

        Console.Write("Write the frequency of this income. It is Monthly, Weekly, Biweekly, Yearly: ");
        string frequency = Console.ReadLine();

        // Set isIncome to true
         bool isIncome = true;

        // Create new Income object and add it to the list
        Income newIncome = new Income(description, amount, date, category, isIncome, frequency);
        expenses.Add(newIncome);

        // Save the entry using FileManager
        FileManager fileManager = new FileManager("report.txt");
        string reportContent = $"Type: Income, Category: {category}, Description: {description}, Amount: ${amount:N2}, Date: {date.ToString("MM/dd/yyyy")}, Frequency: {frequency}";
        fileManager.SaveReport(reportContent);

        Console.WriteLine("Income added successfully and saved to report.txt!");

        // Update the view report after adding the new entry
        ViewReport();
         
    }


    // Method to add Fixed Expenses
    static void AddFixedExpense(List<Expense> expenses, List<string> fixedExpenseCategories)
    {
        Console.Write("Enter fixed expense description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the amount of fixed expense ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid amount:");
            Console.Write("Amount: ");
        }

        Console.Write("Enter the date when you incurred on this fixed expense:(MM/DD/YYYY): ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            Console.WriteLine("Invalid date format. Please enter the date in MM/DD/YYYY format:");
            Console.Write("Date (MM/DD/YYYY): ");
        }
        // Display the categories for the user to choose from
        Console.WriteLine("Select a category for this Fixed Expense:");
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

        // Save the entry using FileManager
        FileManager fileManager = new FileManager("report.txt");
        string reportContent = $"Type: Fixed Expense, Category: {category}, Description: {description}, Amount: ${amount:N2}, Date: {date.ToString("MM/dd/yyyy")}";
        fileManager.SaveReport(reportContent);

        Console.WriteLine("Fixed Expense added successfully!");
        // Update the view report after adding the new entry
        ViewReport();
    
    }


    // Method to add Recurring Income
    static void AddRecurringIncome(List<Expense> expenses)
    {
        Console.Write("Enter a description for the recurring income: "); 
        string description = Console.ReadLine(); 

        Console.Write("Enter the source of your income (e.g., Salary/Wages, Investment, Business, Gift, Other): ");
        string category = Console.ReadLine();

        Console.Write("Enter the amount of income: ");
        decimal amount;
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid amount:");
            Console.Write("Amount: ");
        }

        Console.Write("Enter the date of income:(MM/DD/YYYY): ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {   
            Console.WriteLine("Invalid date format. Please enter the date in MM/DD/YYYY format:");
            Console.Write("Date (MM/DD/YYYY): ");
        }

        Console.Write("How often do you receive this income (e.g., Monthly, Weekly, Biweekly, Yearly): ");
        string frequency = Console.ReadLine();

        // additional information  for recurring income
        Console.Write("Provide any additional details about the recurrence of this income: ");
        string recurrence = Console.ReadLine();

        // Save the entry using FileManager
        FileManager fileManager = new FileManager("report.txt");
        string reportContent = $"Type: Recurring Income, Category: {category}, Description: {description}, Amount: ${amount:N2}, Date: {date.ToString("MM/dd/yyyy")}, Frequency: {frequency}";
        fileManager.SaveReport(reportContent);

        Console.WriteLine("Recurring Income added successfully!");
        // Update the view report after adding the new entry
        ViewReport();
        
    }

    // Method to view categories
    static void ViewCategories(List<Category> categories, List<string> fixedExpenseCategories)
    {
        Console.WriteLine("Regular Categories:");
        foreach (Category category in categories)
        {
            Console.WriteLine($"Name: {category.GetName()}");
            Console.WriteLine($"Description: {category.GetDescription()}");
            Console.WriteLine("--------------------");
        }

        Console.WriteLine("Fixed Expense Categories:");
        foreach (string fixedCategory in fixedExpenseCategories)
        {
            Console.WriteLine($"Name: {fixedCategory}");
            Console.WriteLine($"Description: Fixed Expense");
            Console.WriteLine("--------------------");
        }
    }


    // Method to view report
    static void ViewReport()
    {
    FileManager fileManager = new FileManager("report.txt");
    string reportContent = fileManager.LoadReport();

    if (string.IsNullOrEmpty(reportContent))
    {
        Console.WriteLine("No data available in the report.");
        return;
    }

    string[] entries = reportContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    Console.WriteLine("=== Sorted Entries ===");
    Console.WriteLine("Type                Category            Description                  Amount         Date       Frequency");
    Console.WriteLine("------             -----------          ------------                 -------        ------     --------- ");

    decimal totalExpenses = 0;
    decimal totalIncome = 0;

    foreach (string entry in entries)
    {
        string[] parts = entry.Split(", ");
        if (parts.Length >= 5)
        {
            string type = parts[0].Split(": ")[1];
            string category = parts[1].Split(": ")[1];

            string description = "";
            if (parts.Length >= 3)
            {
                description = parts[2].Split(": ")[1];
            }
            else
            {
                Console.WriteLine($"Invalid entry format: {entry}");
                continue; 
            }

            decimal amount = decimal.Parse(parts[3].Split(": ")[1].Trim('$'), NumberStyles.Currency);
            DateTime date = DateTime.ParseExact(parts[4].Split(": ")[1], "MM/dd/yyyy", CultureInfo.InvariantCulture);

            string frequency = "";
            if (parts.Length >= 6)
                {
                    frequency = parts[5].Split(": ")[1];
                }

            if (type == "Expense" || type == "Fixed Expense")
                {
                    totalExpenses += amount;
                    Console.WriteLine($"{type,-20}{category,-20}{description,-30}{amount,-14:C}{date.ToString("MM/dd/yyyy"),-12}{frequency}");
                }
            else if (type == "Income" || type == "Recurring Income")
                {
                    totalIncome += amount;
                    Console.WriteLine($"{type,-20}{category,-20}{description,-30}{amount,-14:C}{date.ToString("MM/dd/yyyy"),-12}{frequency}");
                }
        }
            else
                {
                    Console.WriteLine($"Invalid entry format: {entry}");
                }
    }

        Console.WriteLine($"\nTotal Expenses: {totalExpenses:C}");
        Console.WriteLine($"Total Income: {totalIncome:C}");

        if (totalExpenses > totalIncome)
        {
            Console.WriteLine("You are spending more than your income. Consider adjusting your expenses.");
        }
        else
        {
            Console.WriteLine("Your budgeting seems balanced. Keep up the good work!");
        }
    }
}
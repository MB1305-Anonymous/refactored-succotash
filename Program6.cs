using System;

class BankAccount
{
    private decimal balance;

    public BankAccount(decimal initialBalance = 0)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}.");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount:C}. New balance: {balance:C}.");
        }
        else if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Current balance: {balance:C}.");
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(100000); 
        bool continueTransactions = true;

        while (continueTransactions)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");

            string input = Console.ReadLine();
            decimal amount;

            switch (input)
            {
                case "1":
                    Console.Write("Enter deposit amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        account.Deposit(amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case "2":
                    Console.Write("Enter withdrawal amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        account.Withdraw(amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case "3":
                    account.CheckBalance();
                    break;

                case "4":
                    continueTransactions = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

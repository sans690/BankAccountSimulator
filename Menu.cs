using System;
using System.Reflection.Metadata;

class Menu
{
    // might try to do this with sql server management, but on mac right now


    static List<List<int>> cardsList = [[1, 111, 100], [2, 222, 50], [3, 333, 0]];

    static Users user = new Users();

    public static void Run(string[] args)
    {
        verifyAccount(user);
    }


    public static bool yesOrNo(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            Console.WriteLine("Enter y for yes and n for no");
            string? options = Console.ReadLine()?.ToLower();

            if (options == "y")
            {
                return true;
            }
            if (options == "n")
            {
                return false;
            }
            Console.WriteLine("Invalid input, please enter y or n");
        }
    }

    public static void selectionOptions(Users user)
    {
        bool continueTransactions = true;
        while (continueTransactions)
        {
            Console.WriteLine("Please select from the options listed below");
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Withdraw amount");
            Console.WriteLine("3. Deposit amount");
            Console.WriteLine("4. Self destruct?");
            Console.WriteLine("5. Need help?");
            Console.WriteLine("6. Exit");
            string? options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    try
                    {
                        user.balance = Balance.checkBalance(user);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    break;

                case "2":
                    try
                    {
                        user.balance = Balance.withdraw(user);
                        for (int i = 0; i < cardsList.Count; i++)
                        {
                            cardsList[i][2] = user.balance;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    break;

                case "3":
                    try
                    {
                        user.balance = Balance.deposit(user);

                        for (int i = 0; i < cardsList.Count; i++)
                        {
                            cardsList[i][2] = user.balance;
                            Console.WriteLine(cardsList[i][2]);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                    }
                    break;

                case "4":
                    try
                    {
                        Balance.getRobbed();
                    }
                    catch
                    {

                    }
                    break;

                case "5":
                    try
                    {
                        ChatBot.Chat();
                    }
                    catch
                    {

                    }
                    break;

                case "6":
                    Console.WriteLine("Have a good day!");
                    return;

                default:
                    Console.WriteLine("Invalid user input");
                    break;
            }
            continueTransactions = yesOrNo("Do you want to make another transaction?");
        }
    }

    public static void verifyAccount(Users user)
    {
        bool isValid = false;
        Console.WriteLine("\nWelcome to the bank");

        Console.WriteLine("Please enter your card number");
        string? cardNumber = Console.ReadLine();
        int.TryParse(cardNumber, out int cardNumberInt);
        user.cardNumber = cardNumberInt;

        Console.WriteLine("Please enter your card pin");
        string? cardPin = Console.ReadLine();
        int.TryParse(cardPin, out int cardPinInt);
        user.cardPin = cardPinInt;

        for (int i = 0; i < cardsList.Count; i++)
        {
            if (cardsList[i][0] == user.cardNumber && cardsList[i][1] == user.cardPin)
            {
                isValid = true;
                user.balance = cardsList[i][2];
                // Console.WriteLine(user.balance);
            }
        }

        if (!isValid)
        {
            throw new ArgumentException("Input not found in list");
        }

        if (isValid)
        {
            selectionOptions(user);
        }
    }
}
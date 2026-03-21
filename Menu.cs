using System;

class Menu
{
    // might try to do this with sql server management, but on mac
    List<int> cardPinsList = new List<int> { };
    List<int> cardNumbersList = new List<int> { };

    public static void Run(string[] args)
    {
        selectionOptions();
    }

    public static void selectionOptions()
    {
        bool isValidCardNumber = false;
        bool isValidCardPin = false;
        Users user = new Users();
        Console.WriteLine("Welcome to the bank");

        Console.WriteLine("Please enter your card number");
        string? cardNumber = Console.ReadLine();
        int.TryParse(cardNumber, out int cardNumberInt);
        user.cardNumber = cardNumberInt;

        Console.WriteLine("Please enter your card pin");
        string? cardPin = Console.ReadLine();
        int.TryParse(cardPin, out int cardPinInt);
        user.cardPin = cardPinInt;

        Console.WriteLine("Please select from the options listed below");
        Console.WriteLine("1. Check balance");
        Console.WriteLine("2. Withdraw amount");
        Console.WriteLine("3. Deposit amount");
        Console.WriteLine("4. Self Destruct?");
        Console.WriteLine("5. Exit");
        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                try
                {
                    Balance.checkBalance();
                }
                catch
                {

                }
                break;

            case "2":
                try
                {
                    Balance.withdraw();
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
                break;

            case "3":
                try
                {
                    Balance.deposit();
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException(ex.Message);
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
                Environment.Exit(0);
                break;
        }
    }
}
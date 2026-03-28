using System;

class Balance
{
    public static void checkBalance(Users user)
    {
        Console.WriteLine($"{user.balance}");
    }
    public static void withdraw(Users user)
    {
        int amountInt = 0;

        Console.WriteLine("Enter the amount you would like to withdraw:");
        string? amount = Console.ReadLine();
        int.TryParse(amount, out amountInt);
        int result = user.balance - amountInt;
        user.balance = result;
        Console.WriteLine($"Taking ${amountInt} from your account");
        Console.WriteLine($"Remaining Balance: ${user.balance}");

        // if (amountInt > user.balance)
        // {
        //     throw new InvalidOperationException($"Your balance shows {user.balance}. The amount {amountInt} to withdraw is larger than the balance for the user.");
        // }
    }

    public static void deposit()
    {

    }

    public static void getRobbed()
    {

    }
}
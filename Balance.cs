using System;
using System.Net;

class Balance
{
    public static int checkBalance(Users user)
    {
        Console.WriteLine($"Balance: ${user.balance}");
        return user.balance;
    }
    public static int withdraw(Users user)
    {
        int amountInt = 0;

        Console.WriteLine("Enter the amount you would like to withdraw:");
        string? amount = Console.ReadLine();
        int.TryParse(amount, out amountInt);

        if (amountInt <= user.balance)
        {
            int result = user.balance - amountInt;
            user.balance = result;

            Console.WriteLine($"Taking ${amountInt} from your account");
            Console.WriteLine($"Remaining Balance: ${user.balance}");
        }
        return user.balance;
    }

    public static void deposit()
    {

    }

    public static void getRobbed()
    {

    }
}
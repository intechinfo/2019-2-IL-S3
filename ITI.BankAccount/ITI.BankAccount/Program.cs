using System;

namespace ITI.BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("FR3712-1234-5678-9012-123", "1234", 0);

            account.Credit(-3000);
            account.Credit(1000);

            account.Debit(500, "0000");
            account.Debit(-3000, "1234");
            account.Debit(2000, "1234");
            account.Debit(-3000, "0000");
            account.Debit(200, "1234");

            Console.WriteLine(account.GetBalance("0000"));
            Console.WriteLine(account.GetBalance("1234"));

            account.SetPassword("0000", "6543");
            Console.WriteLine(account.GetBalance("6543"));

            account.SetPassword("1234", "654321");
            Console.WriteLine(account.GetBalance("654321"));

            account.SetPassword("1234", "4321");
            Console.WriteLine(account.GetBalance("4321"));
            Console.WriteLine(account.GetBalance("1234"));
        }
    }
}

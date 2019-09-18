using System;

namespace ITI.UserManagement.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            User john = new User("John");

            john.UserName = "Johny";

            string userName = john.UserName;
            Console.WriteLine(userName);

            john.SetPassword("ERTERTER");
            if (john.PasswordMatch("ERTERTER"))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failure!");
            }
        }
    }
}

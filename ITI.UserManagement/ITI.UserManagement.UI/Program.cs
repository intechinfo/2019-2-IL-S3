using System;

namespace ITI.UserManagement.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            User john = new User();
            john.SetPassword("ERTERTER");
            if (john.PasswordMatch("spidof"))
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

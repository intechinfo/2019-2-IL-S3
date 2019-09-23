using System;

namespace ITI.BankAccount
{
    class Account
    {
        readonly string _number;

        int _balance;
        string _password;

        public Account(string number, string password, int balance)
        {
            _number = number != null && number.Length >= 8 ? number : Guid.NewGuid().ToString();
            _password = password != null && password.Length == 4 ? password : Guid.NewGuid().ToString().Substring(0, 4);
            _balance = Math.Max(balance, 0);
        }

        public void Credit(int amount)
        {
            _balance += Math.Max(amount, 0);
        }

        public void Debit(int amount, string password)
        {
            if (amount < 0 || amount > _balance) return;
            if (password != _password) return;

            _balance -= amount;
        }

        public int GetBalance(string password)
        {
            return password != _password ? -1 : _balance;
        }

        public void SetPassword(string oldPassword, string newPassword)
        {
            if (oldPassword != _password) return;
            if (newPassword == null) return;
            if (newPassword.Length != 4) return;

            _password = newPassword;
        }
    }
}

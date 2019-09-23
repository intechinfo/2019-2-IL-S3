namespace ITI.UserManagement.UI
{
    class User
    {
        string userName;
        string password;

        public User(string userName)
        {
            this.userName = userName;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public static void SetPassword(User @this, string password)
        {
            @this.password = password;
        }

        public bool PasswordMatch(string candidate)
        {
            return password == candidate;
        }
    }
}

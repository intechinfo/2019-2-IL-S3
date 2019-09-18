namespace ITI.UserManagement.UI
{
    class User
    {
        string _userName;
        string _password;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public void SetPassword(string password)
        {
            _password = password;
        }

        public bool PasswordMatch(string candidate)
        {
            return _password == candidate;
        }
    }
}

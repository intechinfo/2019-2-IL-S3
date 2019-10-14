namespace ITI.MicroZoo
{
    public interface IMailService
    {
        void SendMail(string to, string subject, string body);
    }
}

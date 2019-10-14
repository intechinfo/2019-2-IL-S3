using System;
using System.IO;

namespace ITI.MicroZoo
{
    public class FileSystemMailService : IMailService
    {
        public void SendMail(string to, string subject, string body)
        {
            string text = string.Format(
                "To: {0}, subject: {1}, body: {2}{3}",
                to,
                subject,
                body,
                Environment.NewLine);

            File.AppendAllText(@"D:\mails.log", text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;

namespace ITI.MicroZoo
{
    public class MailService
    {
        public void SendMail(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Antoine Raquillet", "antoine.raquillet@gmail.com"));
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("antoine.raquillet@gmail.com", "password");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}

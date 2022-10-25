using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace IntegrationLibrary.Utilities
{
    public class EmailSending
    {
        private static String _senderName = "PSW Integrations";
        private static String _email = "psw.integrations.g4@gmail.com";
        private static String _password = "mcezencvkdktyarh";

        public static MimeMessage createTxtEmail(String recipientName, String recipientEmail,String subject,String emailText)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_senderName, _email));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));

            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = @"" + emailText
            };
            return message;
        }
        public static void sendEmail(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate(_email, _password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}

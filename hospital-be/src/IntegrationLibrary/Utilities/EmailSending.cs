using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.BloodBanks.Model;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace IntegrationLibrary.Utilities
{
    public class EmailSending
    {
        /*
            private static String _senderName = "PSW Integrations";
            private static String _email = "psw.integrations.g4@gmail.com";
            private static String _password = "mcezencvkdktyarh";
        */
        public static MimeMessage createTxtEmail(String recipientName, String recipientEmail,String subject,String emailText)
        {
            var message = new MimeMessage();

           
            message.From.Add(new MailboxAddress(Settings.EmailingResources.SenderName, Settings.EmailingResources.SenderEmail));
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
                client.Connect(Settings.EmailingResources.SmtpAddress, 587, SecureSocketOptions.StartTls);
                client.Authenticate(Settings.EmailingResources.SenderEmail, Settings.EmailingResources.SenderPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static String CreateEmailText(BloodBank bloodBank)
        {
            //TODO when the public app is done change add the link to EmailingResources and put it here 
            return String.Format(Settings.EmailingResources.EmailTemplate, bloodBank.ApiKey, bloodBank.Password, "Our public app URL goes here");
        }
    }
}

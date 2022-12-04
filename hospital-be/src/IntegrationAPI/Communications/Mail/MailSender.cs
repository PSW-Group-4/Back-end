using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Utilities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace IntegrationAPI.Communications.Mail
{
    public class MailSender : IMailSender
    {
        public string CreateEmailText(BloodBank bloodBank)
        {
            //TODO when the public app is done change add the link to EmailingResources and put it here 
            return string.Format(IntegrationLibrary.Settings.EmailingResources.EmailTemplate, bloodBank.ApiKey, bloodBank.Password, $"http://localhost:4200/bloodBanks/{bloodBank.ApiKey}");
        }

        public MimeMessage createTxtEmail(string recipientName, string recipientEmail, string subject, string emailText)
        {
            MimeMessage message = new MimeMessage();


            message.From.Add(new MailboxAddress(IntegrationLibrary.Settings.EmailingResources.SenderName, IntegrationLibrary.Settings.EmailingResources.SenderEmail));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));

            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = @"" + emailText
            };
            return message;
        }

        public void sendEmail(MimeMessage message)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect(IntegrationLibrary.Settings.EmailingResources.SmtpAddress, 587, SecureSocketOptions.StartTls);
                client.Authenticate(IntegrationLibrary.Settings.EmailingResources.SenderEmail, IntegrationLibrary.Settings.EmailingResources.SenderPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}

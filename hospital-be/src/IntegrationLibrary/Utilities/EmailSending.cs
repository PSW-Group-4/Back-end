using System;
using System.Collections.Generic;
using System.IO;
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
        public static MimeMessage CreateTxtEmail(string recipientName, string recipientEmail,string subject,string emailText)
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

        public static MimeMessage CreateAttachedEmail(string recipientName, string recipientEmail, string subject, string emailText, string attachementName, byte[] attachment)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Settings.EmailingResources.SenderName, Settings.EmailingResources.SenderEmail));
            message.To.Add(new MailboxAddress(recipientName, recipientEmail));

            message.Subject = subject;
            if (attachment != null)
            {
                var bodyBuilder = new BodyBuilder();
                if (attachment != null)
                    bodyBuilder.Attachments.Add(attachementName, attachment);
                bodyBuilder.HtmlBody = emailText;
                message.Body = bodyBuilder.ToMessageBody();
            }
            return message;
        }
        public static void SendEmail(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(Settings.EmailingResources.SmtpAddress, 587, SecureSocketOptions.StartTls);
                client.Authenticate(Settings.EmailingResources.SenderEmail, Settings.EmailingResources.SenderPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public static string CreateEmailText(BloodBank bloodBank)
        {
            //TODO when the public app is done change add the link to EmailingResources and put it here 
            return string.Format(Settings.EmailingResources.EmailTemplate, bloodBank.ApiKey, bloodBank.Password, "Our public app URL goes here");
        }
        public static byte[] CreateEmailAttachment(String path)
        {
            FileStream stream = File.OpenRead(path);
            byte[] fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();
            return fileBytes;
        }
    }
}

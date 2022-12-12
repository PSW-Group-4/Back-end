﻿using System;
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
        public static MimeMessage createTxtEmail(string recipientName, string recipientEmail,string subject,string emailText)
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

        public static string CreateEmailText(BloodBank bloodBank)
        {
            //TODO when the public app is done change add the link to EmailingResources and put it here 
            return string.Format(Settings.EmailingResources.EmailTemplate, bloodBank.ApiKey, bloodBank.Password, "Our public app URL goes here");
        }
    }
}

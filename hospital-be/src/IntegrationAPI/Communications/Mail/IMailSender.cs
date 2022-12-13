using IntegrationLibrary.BloodBanks.Model;
using MimeKit;
using System;

namespace IntegrationAPI.Communications.Mail
{
    public interface IMailSender
    {
        public MimeMessage createTxtEmail(string recipientName, string recipientEmail, string subject, string emailText);
        public void sendEmail(MimeMessage message);
        public string CreateEmailText(BloodBank bloodBank);
    }
}

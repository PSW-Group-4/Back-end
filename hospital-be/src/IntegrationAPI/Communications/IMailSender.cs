using IntegrationLibrary.BloodBanks.Model;
using MimeKit;
using System;

namespace IntegrationAPI.Communications
{
    public interface IMailSender
    {
        public MimeMessage createTxtEmail(String recipientName, String recipientEmail, String subject, String emailText);
        public void sendEmail(MimeMessage message);
        public String CreateEmailText(BloodBank bloodBank);
    }
}

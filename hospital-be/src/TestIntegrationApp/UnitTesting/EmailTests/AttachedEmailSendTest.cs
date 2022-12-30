using IntegrationLibrary.Utilities;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting.EmailTests
{
    public class AttachedEmailSendTest
    {
        [Fact]
        public void Mail_is_being_sent()
        {
            byte[] attachment = EmailSending.CreateEmailAttachment(@"E:\metoda-dekompozicije.pdf");
            MimeMessage email = EmailSending.CreateAttachedEmail("Marko", "matijamedic2000@gmail.com", "Integration testing", "This is a test", "metoda-dekompozicije.pdf", attachment);
            EmailSending.SendEmail(email);
        }
    }
}

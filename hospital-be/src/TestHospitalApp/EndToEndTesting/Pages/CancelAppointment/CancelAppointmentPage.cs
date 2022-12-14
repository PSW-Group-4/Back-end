using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.CancelAppointment
{
    public class CancelAppointmentPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/manager/consiliums";
        public const string LoginURI = @"http://localhost:4200/login";
    }
}

using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class AdmissionReasonTest
    {
        [Fact]
        public void Valid_admmission_reason()
        {
            string reason = "Glavobolja";

            Reason admissionReason = new Reason(reason);

            admissionReason.ShouldNotBeNull();
        }

        [Fact]
        public void Valid_admmission_reason_with_space()
        {
            string reason = "Glavobolja od vina";

            Reason admissionReason = new Reason(reason);

            admissionReason.ShouldNotBeNull();
        }

        [Fact]
        public void Invalid_admmission_reason_first_lowercase()
        {
            string reason = "glavobolja od vina";            

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Reason admissionReason = new Reason(reason);
            });
        }

        [Fact]
        public void Invalid_admmission_reason_empty_string()
        {
            string reason = "";

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Reason admissionReason = new Reason(reason);
            });
        }
    }
}

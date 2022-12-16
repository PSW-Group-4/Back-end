using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Reports.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class ConsiliumRequestTest
    {
        [Fact]
        public void Valid_consilium_request()
        {
            string Reason = "Pomoch mi treba";
            DateTime DateStart = DateTime.Now;
            DateTime DateEnd = DateTime.Now.AddHours(1);
            int Duration = 2;
            bool isDoctor = true;
            Guid guid = new Guid("2122d4ea-ba72-40ef-b87c-29c1daacf75f");
            List<Guid> DoctorsId = new List<Guid>();
            List<string> Specialities = new List<string>();
            DoctorsId.Add(guid);
            ConsiliumRequest consiliumrequest = new ConsiliumRequest
                (
                Reason,
                DateStart,
                DateEnd,
                Duration,
                isDoctor,
                DoctorsId,
                Specialities
                );

            consiliumrequest.ShouldNotBeNull();
        }

        [Fact]
        public void Invalid_consilium_request()
        {
            string Reason = "Pomoch mi treba";
            DateTime DateStart = DateTime.Now;
            DateTime DateEnd = DateTime.Now.AddHours(1);
            int Duration = 2;
            bool isDoctor = false;
            Guid guid = new Guid("2122d4ea-ba72-40ef-b87c-29c1daacf75f");
            List<Guid> DoctorsId = new List<Guid>();
            List<string> Specialities = new List<string>();
            DoctorsId.Add(guid);


            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                ConsiliumRequest consiliumrequest = new ConsiliumRequest (
                Reason,
                DateStart,
                DateEnd,
                Duration,
                isDoctor,
                DoctorsId,
                Specialities
                );
            });
        }
    }
}

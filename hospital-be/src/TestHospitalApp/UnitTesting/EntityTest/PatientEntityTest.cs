using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using IntegrationLibrary.Common;
using Shouldly;
using System;
using HospitalLibrary.Doctors.Model;
using Xunit;

namespace TestHospitalApp.UnitTesting.EntityTest
{

    public class PatientEntityTest
    {
        [Fact]
        public void Valid_Patient()
        {
            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Patient p = new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", new DateTime(2015, 1, 1), Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            p.ShouldNotBe(null);
        }



        [Fact]
        public void Invalid_Patient()
        {
            Address address = new Address { Id = new Guid(), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Should.Throw<EntityObjectValidationFailedException>(() =>
                new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "", "Popovic", new DateTime(2015, 1, 1),
                    Gender.Male, address, new Jmbg("1807000730038"),
                    new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+")));

        }



        [Fact]
        public void Invalid_Doctor_For_Patient()
        {
            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Patient p = new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", new DateTime(2015, 1, 1), Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            
            Should.Throw<EntityObjectValidationFailedException>(() => p.AppointTheChosenDoctor(null));

        }



    }
}

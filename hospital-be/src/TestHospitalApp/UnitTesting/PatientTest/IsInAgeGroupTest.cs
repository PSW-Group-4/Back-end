using HospitalLibrary.Patients.Model;
using Shouldly;
using System;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Common;
using Xunit;

namespace TestHospitalApp.PatientTest
{
    public class IsInAgeGroupTest
    {

        [Fact]
        public void Checks_if_patient_is_in_certain_age_group()
        {
            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Patient p = new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", new DateTime(2015, 1, 1), Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            AgeGroup ageGroup = new AgeGroup("TEST", 0, 20);
            bool isInAgeGroup = p.IsInAgeGroup(ageGroup);

            isInAgeGroup.ShouldBe(true);

        }

        [Fact]
        public void Checks_if_patient_is_not_in_certain_age_group()
        {

            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Patient p = new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", new DateTime(1970, 1, 1), Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            AgeGroup ageGroup = new AgeGroup("TEST", 0, 20);

            bool isInAgeGroup = p.IsInAgeGroup(ageGroup);

            isInAgeGroup.ShouldBe(false);

        }

        [Fact]
        public void Checks_if_patient_is_in_certain_age_group_if_birthday_is_today()
        {
         
            int age = 20;
            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Patient p = new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day), Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            AgeGroup ageGroup = new AgeGroup("TEST", 0, age);

            bool isInAgeGroup = p.IsInAgeGroup(ageGroup);

            isInAgeGroup.ShouldBe(false);

        }


    }
}

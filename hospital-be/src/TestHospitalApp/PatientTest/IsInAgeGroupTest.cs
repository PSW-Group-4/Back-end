using HospitalLibrary.Patients.Model;
using HospitalLibrary.Utility;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.PatientTest
{
    public class IsInAgeGroupTest
    {

        [Fact]
        public void Checks_if_patient_is_in_certain_age_group()
        {
            Patient p = new Patient();
            p.Birthdate = new DateTime(2015, 1, 1);
            AgeGroup ageGroup = new AgeGroup("TEST",0,20);

            bool isInAgeGroup = p.IsInAgeGroup(ageGroup);


            isInAgeGroup.ShouldBe(true);

        }

        [Fact]
        public void Checks_if_patient_is_not_in_certain_age_group()
        {
            Patient p = new Patient();
            p.Birthdate = new DateTime(1970, 1, 1);
            AgeGroup ageGroup = new AgeGroup("TEST", 0, 20);
            bool isInAgeGroup = p.IsInAgeGroup(ageGroup);

            isInAgeGroup.ShouldBe(false);

        }

        [Fact]
        public void Checks_if_patient_is_in_certain_age_group_if_birthday_is_today()
        {
            Patient p = new Patient();
            int age = 20;
            p.Birthdate = new DateTime(DateTime.Now.Year- age, DateTime.Now.Month, DateTime.Now.Day);

            AgeGroup ageGroup = new AgeGroup("TEST", 0, age);
            bool isInAgeGroup = p.IsInAgeGroup(ageGroup);

            isInAgeGroup.ShouldBe(false);

        }


    }
}

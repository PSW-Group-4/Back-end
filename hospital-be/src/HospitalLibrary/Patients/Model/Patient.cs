using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Patients.Model
{

    public class Patient : Person
    {
        public BloodType BloodType { get; set; }
        public virtual List<Allergie> Allergies { get; set; }
        public Guid ChoosenDoctorId { get; set; }
        public virtual Doctor ChoosenDoctor { get; set; }

        public void Update(Patient patient)
        {
            base.Update(patient);
            BloodType = patient.BloodType;
            Allergies = patient.Allergies;
            ChoosenDoctorId = patient.ChoosenDoctorId;
            ChoosenDoctor = patient.ChoosenDoctor;
        }

        public bool IsInAgeGroup(AgeGroup ageGroup)
        {
            return DateTime.Now.AddYears(-ageGroup.MaxAge) <= Birthdate && DateTime.Now.AddYears(-ageGroup.MinAge) >= Birthdate;
        }
    }
}

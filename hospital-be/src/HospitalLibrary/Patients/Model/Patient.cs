using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Patients.Model
{

    public class Patient : Person
    {
<<<<<<< HEAD
        public Patient(Guid id, string name, string surname, DateTime birthdate, Gender gender, Address address,
            Jmbg jmbg, Email email, string phoneNumber, BloodType bloodType) : base(id, name, surname, birthdate,
            gender, address, jmbg, email, phoneNumber)
        {
            BloodType = bloodType;
            Allergies = new List<Allergie>();
            Validate();
        }

        public Patient() : base() {}

    public BloodType BloodType { get; private set; }
        public virtual List<Allergie> Allergies { get; set; }
       
        
        public Guid ChosenDoctorId { get; private set; }
        public virtual Doctor ChosenDoctor { get; private set; }
=======
        public BloodType BloodType { get; set; }
        public virtual List<Allergie> Allergies { get; set; }
        public Guid ChoosenDoctorId { get; set; }
        public virtual Doctor ChoosenDoctor { get; set; }
>>>>>>> parent of f175851 (Person user doctor patient ddd)

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

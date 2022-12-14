using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Patients.Model
{

    public class Patient : Person
    {
        public Patient(Guid id, string name, string surname, DateTime birthdate, Gender gender, Address address,
            Jmbg jmbg, Email email, string phoneNumber, BloodType bloodType) : base(id, name, surname, birthdate,
            gender, address, jmbg, email, phoneNumber)
        {
            BloodType = bloodType;
            Validate();
        }

        public Patient() : base()
        {}

    public BloodType BloodType { get; private set; }
        public virtual List<Allergie> Allergies
        {
            get { return new List<Allergie>(Allergies);}

            private set{}

        }
        public Guid ChosenDoctorId { get; private set; }
        public virtual Doctor ChosenDoctor { get; private set; }

        public void Update(Patient patient)
        {
            base.Update(patient);
            BloodType = patient.BloodType;
            Allergies = patient.Allergies;
            ChosenDoctorId = patient.ChosenDoctorId;
            ChosenDoctor = patient.ChosenDoctor;
        }

        public void AppointTheChosenDoctor(Doctor doctor)
        {
            if (doctor.Equals(null))
                throw new EntityObjectValidationFailedException();
            if (doctor.Id.Equals(null))
                throw new EntityObjectValidationFailedException();

            ChosenDoctor = doctor;
            ChosenDoctorId = doctor.Id;

        }

        public void AddStartingAllergies(List<Allergie> allergies)
        {
            if (allergies.Equals(null))
                Allergies = new List<Allergie>();
            Allergies = allergies;

        }

        private void Validate()
        {
            if (BloodType.Equals(null))
                throw new EntityObjectValidationFailedException();
       
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool IsInAgeGroup(AgeGroup ageGroup)
        {
            return DateTime.Now.AddYears(-ageGroup.MaxAge) <= Birthdate && DateTime.Now.AddYears(-ageGroup.MinAge) >= Birthdate;
        }
    }
}

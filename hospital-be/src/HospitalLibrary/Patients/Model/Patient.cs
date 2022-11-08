using HospitalLibrary.Allergies;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Patients.Model
{
    public enum BloodType
    {
        A_POS,
        A_NEG,
        B_POS,
        B_NEG,
        O_POS,
        O_NEG,
        AB_POS,
        AB_NEG
    }

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
    }
}

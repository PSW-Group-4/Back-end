using System;
using System.Collections.Generic;
using HospitalAPI.Dtos.Person;
using HospitalLibrary.Allergies.Model;
using IntegrationLibrary.Common;

namespace HospitalAPI.Dtos.Patient
{
    public class PatientGetResponseDto : PersonGetResponseDto
    {
        public BloodType BloodType { get; set; }
        public virtual List<Allergie> Allergies { get; set; }
        public Guid ChoosenDoctorId { get; set; }
        public virtual HospitalLibrary.Doctors.Model.Doctor ChoosenDoctor { get; set; }
    }
}
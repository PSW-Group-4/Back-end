using HospitalAPI.Dtos.Person;
using HospitalLibrary.Allergies;
using HospitalLibrary.Patients.Model;
using System.Collections.Generic;
using System;

namespace HospitalAPI.Dtos.Patient
{
    public class PatientRequestDto : PersonRequestDto
    {
        public BloodType BloodType { get; set; }
        public List<Allergie> Allergies { get; set; }
    }
}
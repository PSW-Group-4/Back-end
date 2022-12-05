using HospitalAPI.Dtos.Person;
using HospitalLibrary.Patients.Model;
using System.Collections.Generic;
using System;
using HospitalLibrary.Allergies.Model;
using IntegrationLibrary.Common;

namespace HospitalAPI.Dtos.Patient
{
    public class PatientRequestDto : PersonRequestDto
    {
        public BloodType BloodType { get; set; }
        public List<Allergie> Allergies { get; set; }
    }
}
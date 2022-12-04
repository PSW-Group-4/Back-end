using HospitalAPI.Dtos.Person;
using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Patients.Model;
using System.Collections.Generic;
using HospitalLibrary.Doctors.Model;
using HospitalAPI.Dtos.Allergies;
using HospitalAPI.Dtos.Doctor;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;

namespace HospitalAPI.Dtos.Patient
{
    public class PatientInfoDto : PersonRequestDto
    {
        public BloodType BloodType { get; set; }
        public List<AllergieInfoDto> Allergies { get; set; }
        public DoctorRequestDto ChoosenDoctor { get; set; }
    }
}

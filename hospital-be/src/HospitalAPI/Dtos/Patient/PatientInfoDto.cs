using HospitalAPI.Dtos.Person;
using HospitalLibrary.Patients.Model;

namespace HospitalAPI.Dtos.Patient
{
    public class PatientInfoDto : PersonRequestDto
    {
        public BloodType BloodType { get; set; }
    }
}

using HospitalAPI.Dtos.Person;

namespace HospitalAPI.Dtos.Patient
{
    public class PatientRequestDto : PersonRequestDto
    {
        public string Lbo { get; set; }
        public bool Blocked { get; set; }
    }
}
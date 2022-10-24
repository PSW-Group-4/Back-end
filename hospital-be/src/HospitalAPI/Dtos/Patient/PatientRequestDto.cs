using HospitalAPI.Controllers.Dtos.Person;

namespace HospitalAPI.Controllers.Dtos.Patient
{
    public class PatientRequestDTO : PersonRequestDto
    {
        public string Lbo { get; set; }
        public bool Blocked { get; set; }
    }
}
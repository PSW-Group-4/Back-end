using HospitalAPI.Dtos.Person;

namespace HospitalAPI.Dtos.Doctor
{
    public class DoctorRequestDto : PersonRequestDto
    {
        public string LicenceNum { get; set; }
        public string Speciality { get; set; }
        public string WorkingTimeStart { get; set; }
        public string WorkingTimeEnd { get; set; }
    }
}

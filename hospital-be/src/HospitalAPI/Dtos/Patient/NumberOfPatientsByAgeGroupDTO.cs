using HospitalLibrary.Patients.Model;

namespace HospitalAPI.Dtos.Patient
{
    public class NumberOfPatientsByAgeGroupDTO
    {
        public AgeGroup AgeGroup { get; set; }
        public int PatientCount { get; set; }
    }
}

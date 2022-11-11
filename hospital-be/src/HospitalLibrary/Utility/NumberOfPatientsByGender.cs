using HospitalLibrary.Core.Model;

namespace HospitalAPI.Dtos.Patient
{
    public class NumberOfPatientsByGender
    {
        public Gender Gender { get; set; }

        public int PatientCount { get; set; }

        public NumberOfPatientsByGender(Gender gender, int patientCount)
        {
            Gender = gender;
            PatientCount = patientCount;
        }
    }
}

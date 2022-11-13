using HospitalLibrary.Core.Model;

namespace HospitalAPI.Dtos.Patient
{
    public class NumberOfPatientsByGenderDTO
    {
        public Gender Gender { get; set; }

        public int PatientCount { get; set; }


    }
}

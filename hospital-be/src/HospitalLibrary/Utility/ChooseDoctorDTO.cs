using System;

namespace HospitalLibrary.Doctors.Service
{
    public class ChooseDoctorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PatientCount { get; set; }

        public ChooseDoctorDTO(Guid id, string name, string surname, int patientCount)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.PatientCount = patientCount;
        }
    }
}
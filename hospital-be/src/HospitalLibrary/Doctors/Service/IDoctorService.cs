using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Doctors.Service
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(Guid id);
        Doctor Create(Doctor doctor);
        Doctor Update(Doctor doctor);
        void Delete(Guid doctorId);

        IEnumerable<ChooseDoctorDTO> DoctorsWithLeastPatients();
        public IEnumerable<string> GetAllSpecialties();
        public IEnumerable<Doctor> GetDoctorsWithSpecialty(string specialty);

    }
}

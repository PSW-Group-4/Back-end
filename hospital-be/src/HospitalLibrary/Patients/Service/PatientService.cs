using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Patients.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _PatientRepository;

        public PatientService(IPatientRepository PatientRepository)
        {
            _PatientRepository = PatientRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _PatientRepository.GetAll();
        }

        public Patient GetById(Guid id)
        {
            return _PatientRepository.GetById(id);
        }

        public void Create(Patient Patient)
        {
            _PatientRepository.Create(Patient);
        }

        public void Update(Patient Patient)
        {
            _PatientRepository.Update(Patient);
        }

        public void Delete(Patient Patient)
        {
            _PatientRepository.Delete(Patient);
        }
    }
}

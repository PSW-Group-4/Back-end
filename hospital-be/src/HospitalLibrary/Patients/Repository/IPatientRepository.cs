using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Patients.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(Guid id);
        void Create(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
    }
}

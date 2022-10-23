using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Patients.Service
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(Guid id);
        void Create(Patient Patient);
        void Update(Patient Patient);
        void Delete(Patient Patient);
    }
}

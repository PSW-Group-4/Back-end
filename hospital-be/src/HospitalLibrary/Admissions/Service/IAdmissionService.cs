using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Admissions.Model;

namespace HospitalLibrary.Admissions.Service
{
    public interface IAdmissionService
    {
        IEnumerable<Admission> GetAll();
        Admission GetById(Guid id);
        Admission Create(Admission admission);
        Admission Update(Admission admission);
        void Delete(Guid id);
        public Admission UpdateTreatment(Admission admission, Guid treatmentId);

    }
}

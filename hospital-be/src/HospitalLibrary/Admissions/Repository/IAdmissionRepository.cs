using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Admissions.Model;

namespace HospitalLibrary.Admissions.Repository
{
    public interface IAdmissionRepository : IRepositoryBase<Admission>
    {
        public Admission UpdateTreatment(Admission admission, Guid treatmentId);
    }
}

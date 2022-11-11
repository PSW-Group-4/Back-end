using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Admissions.Repository;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.Admissions.Service
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IAdmissionRepository _admissionRepository;

        public AdmissionService(IAdmissionRepository admissionRepository)
        {
            _admissionRepository = admissionRepository;
        }
        public IEnumerable<Admission> GetAll()
        {
            return _admissionRepository.GetAll();
        }

        public Admission GetById(Guid id)
        {
            return _admissionRepository.GetById(id);
        }

        public Admission Create(Admission admission)
        {
            return _admissionRepository.Create(admission);
        }

        public Admission Update(Admission admission)
        {
            return _admissionRepository.Update(admission);
        }

        public void Delete(Guid admissionId)
        {
            _admissionRepository.Delete(admissionId);
        }
    }
}

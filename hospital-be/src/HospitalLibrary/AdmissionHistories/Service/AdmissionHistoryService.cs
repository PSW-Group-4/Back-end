using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Repository;
using HospitalLibrary.Admissions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AdmissionHistories.Service
{
    public class AdmissionHistoryService : IAdmissionHistoryService
    {

        private readonly IAdmissionHistoryRepository _admissionRepository;

        public AdmissionHistoryService(IAdmissionHistoryRepository admissionRepository)
        {
            _admissionRepository = admissionRepository;
        }
        public AdmissionHistory Create(AdmissionHistory admission)
        {
            return _admissionRepository.Create(admission);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdmissionHistory> GetAll()
        {
            return _admissionRepository.GetAll();
        }

        public AdmissionHistory GetById(Guid id)
        {
            return _admissionRepository.GetById(id);
        }

        public AdmissionHistory Update(AdmissionHistory admission)
        {
            throw new NotImplementedException();
        }
    }
}

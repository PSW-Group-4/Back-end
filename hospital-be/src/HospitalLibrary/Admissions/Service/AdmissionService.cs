using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Repository;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Admissions.Repository;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.Admissions.Service
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IAdmissionRepository _admissionRepository;
        private readonly IAdmissionHistoryRepository _admissionHistoryRepository;

        public AdmissionService(IAdmissionRepository admissionRepository, IAdmissionHistoryRepository admissionHistoryRepository)
        {
            _admissionRepository = admissionRepository;
            _admissionHistoryRepository = admissionHistoryRepository;
        }
        public IEnumerable<Admission> GetAll()
        {
            List<Admission> fineAdmissions = new List<Admission>();
            List<Admission> admissions = (List<Admission>)_admissionRepository.GetAll();
            List<AdmissionHistory> admissionHistories = (List<AdmissionHistory>)_admissionHistoryRepository.GetAll();
            foreach(Admission admission in admissions)
            {
                Boolean isExist = false;
                foreach(AdmissionHistory admissionHistory in admissionHistories)
                {
                    if (admission.Id.Equals(admissionHistory.Admission.Id))
                    {
                        isExist = true;
                    }
                }
                if (!isExist)
                    fineAdmissions.Add(admission);
            }
            return fineAdmissions;
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
        public Admission UpdateTreatment(Admission admission, Guid treatmentId)
        {
            return _admissionRepository.UpdateTreatment(admission, treatmentId);
        }
    }
}

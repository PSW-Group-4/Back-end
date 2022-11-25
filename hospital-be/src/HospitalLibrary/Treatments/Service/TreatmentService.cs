using HospitalLibrary.Medicines.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Treatments.Model;
using HospitalLibrary.Treatments.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Treatments.Service
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }
        public IEnumerable<Treatment> GetAll()
        {
            return _treatmentRepository.GetAll();
        }

        public Treatment GetById(Guid id)
        {
            return _treatmentRepository.GetById(id);
        }

        public Treatment Create(Treatment entity)
        {
            return _treatmentRepository.Create(entity);
        }

        public Treatment Update(Treatment entity)
        {
            return _treatmentRepository.Update(entity);
        }

        public void Delete(Guid entityId)
        {
            _treatmentRepository.Delete(entityId);
        }
        public Treatment UpdateMedicine(Treatment treatment, Guid medicineId)
        {
           return _treatmentRepository.UpdateMedicine(treatment, medicineId);
        }
        public Treatment UpdateBloodConsuptionRecord(Treatment treatment, Guid bcrId)
        {
            return _treatmentRepository.UpdateBloodConsuptionRecord(treatment, bcrId);
        }
    }
}

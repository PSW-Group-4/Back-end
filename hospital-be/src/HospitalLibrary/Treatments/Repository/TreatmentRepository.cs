using HospitalLibrary.Exceptions;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;
using HospitalLibrary.Treatments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Treatments.Repository
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly HospitalDbContext _context;
        public TreatmentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public Treatment Create(Treatment entity)
        {
            _context.Treatments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid treatmentId)
        {
            var treatment = GetById(treatmentId);
            _context.Treatments.Remove(treatment);
            _context.SaveChanges();
        }

        public IEnumerable<Treatment> GetAll()
        {
            return _context.Treatments.ToList();
        }

        public Treatment GetById(Guid id)
        {
            var result = _context.Treatments.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Treatment Update(Treatment treatment)
        {
            var updatingTreatment = _context.Treatments.SingleOrDefault(p => p.Id == treatment.Id);
            if (updatingTreatment == null)
            {
                throw new NotFoundException();
            }

            updatingTreatment.Update(treatment);

            _context.SaveChanges();
            return updatingTreatment;
        }
        public Treatment UpdateMedicine(Treatment treatment, Guid medicineId)
        {
            var updatingTreatment = _context.Treatments.SingleOrDefault(p => p.Id == treatment.Id);
            
            if (updatingTreatment == null)
            {
                throw new NotFoundException();
            }

            updatingTreatment.UpdateMedicine(medicineId);

            _context.SaveChanges();
            return updatingTreatment;
        }
        public Treatment UpdateBloodConsuptionRecord(Treatment treatment, Guid bcrId)
        {
            var updatingTreatment = _context.Treatments.SingleOrDefault(p => p.Id == treatment.Id);

            if (updatingTreatment == null)
            {
                throw new NotFoundException();
            }

            updatingTreatment.UpdateBloodConsuptionRecord(bcrId);

            _context.SaveChanges();
            return updatingTreatment;
        }
    }
}

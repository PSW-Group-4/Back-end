using HospitalLibrary.Exceptions;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Medicines.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly HospitalDbContext _context;
        public MedicineRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Medicine Create(Medicine entity)
        {
            _context.Medicines.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid medicineId)
        {
            var medicine = GetById(medicineId);
            _context.Medicines.Remove(medicine);
            _context.SaveChanges();
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _context.Medicines.ToList();
        }

        public Medicine GetById(Guid id)
        {
            var result = _context.Medicines.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Medicine Update(Medicine medicine)
        {
            var updatingMedicine = _context.Medicines.SingleOrDefault(p => p.Id == medicine.Id);
            if (updatingMedicine == null)
            {
                throw new NotFoundException();
            }

            updatingMedicine.Update(medicine);

            _context.SaveChanges();
            return updatingMedicine;
        }
    }
}

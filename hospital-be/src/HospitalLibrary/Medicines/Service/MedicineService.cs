using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Medicines.Repository;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Medicines.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }
        public IEnumerable<Medicine> GetAll()
        {
            return _medicineRepository.GetAll();
        }

        public Medicine GetById(Guid id)
        {
            return _medicineRepository.GetById(id);
        }

        public Medicine Create(Medicine medicine)
        {
            return _medicineRepository.Create(medicine);
        }

        public Medicine Update(Medicine medicine)
        {
            return _medicineRepository.Update(medicine);
        }

        public void Delete(Guid id)
        {
            _medicineRepository.Delete(id);
        }
    }
}

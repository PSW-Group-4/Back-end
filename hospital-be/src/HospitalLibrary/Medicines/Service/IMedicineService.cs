using HospitalLibrary.Medicines.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Medicines.Service
{
    public interface IMedicineService
    {
        IEnumerable<Medicine> GetAll();
        Medicine GetById(Guid id);
        Medicine Create(Medicine medicine);
        Medicine Update(Medicine medicine);
        void Delete(Guid medicineId);
    }
}

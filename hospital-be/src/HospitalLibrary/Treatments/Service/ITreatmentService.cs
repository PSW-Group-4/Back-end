using HospitalLibrary.Medicines.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Treatments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Treatments.Service
{
    public interface ITreatmentService
    {
        IEnumerable<Treatment> GetAll();
        Treatment GetById(Guid id);
        Treatment Create(Treatment room);
        Treatment Update(Treatment room);
        void Delete(Guid roomId);
        public Treatment UpdateMedicine(Treatment treatment, Guid medicineId);
        public Treatment UpdateBloodConsuptionRecord(Treatment treatment, Guid bcrId);

    }
}

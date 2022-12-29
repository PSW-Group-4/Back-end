using HospitalLibrary.Core.Repository;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Treatments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Treatments.Repository
{
    public interface ITreatmentRepository : IRepositoryBase<Treatment>
    {
        public Treatment UpdateMedicine(Treatment treatment, Guid medicineId);
        public Treatment UpdateBloodConsuptionRecord(Treatment treatment, Guid bcrId);
    }
}

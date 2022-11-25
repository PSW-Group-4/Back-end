using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Treatments.Model
{
    public class Treatment
    {
        public Guid Id { get; set; }
        public Nullable<Guid> MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public Nullable<Guid> BloodConsumptionRecordId { get; set; }
        public virtual BloodConsumptionRecord BloodConsumptionRecord { get; set; }
        public DateTime DateChanged { get; set; }

        public void Update(Treatment treatment)
        {
            MedicineId = treatment.MedicineId;
            BloodConsumptionRecordId = treatment.BloodConsumptionRecordId;
            DateChanged = treatment.DateChanged;
        }
        public void UpdateMedicine(Guid medicineId)
        {
            DateChanged = DateTime.Now;
            MedicineId = medicineId;
        }
        public void UpdateBloodConsuptionRecord(Guid bcrId)
        {
            DateChanged = DateTime.Now;
            BloodConsumptionRecordId = bcrId;
        }
    }
}

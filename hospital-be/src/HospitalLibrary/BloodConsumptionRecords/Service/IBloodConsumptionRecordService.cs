using HospitalLibrary.BloodConsumptionRecords.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.BloodConsumptionRecords.Service
{
    public interface IBloodConsumptionRecordService
    {
        IEnumerable<BloodConsumptionRecord> GetAll();
        BloodConsumptionRecord GetById(Guid id);
        BloodConsumptionRecord Create(BloodConsumptionRecord bloodConsumptionRecord);
        BloodConsumptionRecord Update(BloodConsumptionRecord bloodConsumptionRecord);
        void Delete(Guid bloodConsumptionRecordId);
    }
}

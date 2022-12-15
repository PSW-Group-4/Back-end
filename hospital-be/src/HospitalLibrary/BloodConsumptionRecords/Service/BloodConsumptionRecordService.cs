using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.BloodConsumptionRecords.Repository;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;
using IntegrationLibrary.BloodUsages.Service;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.BloodConsumptionRecords.Service
{
    public class BloodConsumptionRecordService : IBloodConsumptionRecordService
    {
        private readonly IBloodConsumptionRecordRepository _bloodConsumptionRecordRepository;
        private readonly IBloodSupplyService _bloodSupplyService;

        public BloodConsumptionRecordService(IBloodConsumptionRecordRepository bloodConsumptionRecordRepository, IBloodSupplyService bloodSupplyService)
        {
            _bloodConsumptionRecordRepository = bloodConsumptionRecordRepository;
            _bloodSupplyService = bloodSupplyService;
        }

        public IEnumerable<BloodConsumptionRecord> GetAll()
        {
            return _bloodConsumptionRecordRepository.GetAll();
        }

        public BloodConsumptionRecord GetById(Guid id)
        {
            return _bloodConsumptionRecordRepository.GetById(id);
        }

        public BloodConsumptionRecord Create(BloodConsumptionRecord bloodConsumptionRecord)
        {
            BloodSupply supplyToUpdate = _bloodSupplyService.GetByType(bloodConsumptionRecord.BloodType);

            if (supplyToUpdate.Amount - bloodConsumptionRecord.Amount.Value < 0) return null;
            bloodConsumptionRecord.SetDate();
            supplyToUpdate.Amount = supplyToUpdate.Amount - bloodConsumptionRecord.Amount.Value;
            _bloodSupplyService.Update(supplyToUpdate);

            //_bloodUsageService.Create(ConsumptionUsageConverter.Convert(bloodConsumptionRecord));
            return _bloodConsumptionRecordRepository.Create(bloodConsumptionRecord);
        }

        public BloodConsumptionRecord Update(BloodConsumptionRecord bloodConsumptionRecord)
        {
            return _bloodConsumptionRecordRepository.Update(bloodConsumptionRecord);
        }

        public void Delete(Guid bloodConsumptionRecordId)
        {
            _bloodConsumptionRecordRepository.Delete(bloodConsumptionRecordId);
        }
    }
}

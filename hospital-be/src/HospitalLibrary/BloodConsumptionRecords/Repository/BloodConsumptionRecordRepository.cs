using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Exceptions;
using HospitalLibrary.BloodConsumptionRecords.Model;

namespace HospitalLibrary.BloodConsumptionRecords.Repository
{
    public class BloodConsumptionRecordRepository : IBloodConsumptionRecordRepository
    {
        private readonly HospitalDbContext _context;

        public BloodConsumptionRecordRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodConsumptionRecord> GetAll()
        {
            return _context.BloodConsumptionRecords.ToList();
        }

        public BloodConsumptionRecord GetById(Guid id)
        {
            var result = _context.BloodConsumptionRecords.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public BloodConsumptionRecord Create(BloodConsumptionRecord bloodConsumptionRecord)
        {
            _context.BloodConsumptionRecords.Add(bloodConsumptionRecord);
            _context.SaveChanges();
            return bloodConsumptionRecord;
        }

        public BloodConsumptionRecord Update(BloodConsumptionRecord bloodConsumptionRecord)
        {
            var updatingBloodConsumptionRecord = _context.BloodConsumptionRecords.SingleOrDefault(b => b.Id == bloodConsumptionRecord.Id);
            if (updatingBloodConsumptionRecord == null)
            {
                throw new NotFoundException();
            }

            updatingBloodConsumptionRecord.Update(bloodConsumptionRecord);

            _context.SaveChanges();
            return updatingBloodConsumptionRecord;
        }

        public void Delete(Guid bloodConsumptionRecordId)
        {
            var bloodConsumptionRecord = GetById(bloodConsumptionRecordId);
            _context.BloodConsumptionRecords.Remove(bloodConsumptionRecord);
            _context.SaveChanges();
        }
    }
}

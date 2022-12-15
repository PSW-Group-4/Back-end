using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Repository;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.BloodSupplies.Service
{
    public class BloodSupplyService : IBloodSupplyService
    {
        private readonly IBloodSupplyRepository _bloodSupplyRepository;

        public BloodSupplyService(IBloodSupplyRepository bloodSupplyRepository)
        {
            _bloodSupplyRepository = bloodSupplyRepository;
        }

        public IEnumerable<BloodSupply> GetAll()
        {
            return _bloodSupplyRepository.GetAll();
        }

        public BloodSupply GetById(Guid id)
        {
            return _bloodSupplyRepository.GetById(id);
        }

        public BloodSupply GetByType(string type)
        {
            BloodType supposedType = BloodType.FromString(type);
            return _bloodSupplyRepository.GetByType(supposedType);
        }

        public BloodSupply Create(BloodSupply bloodSupply)
        {
            return _bloodSupplyRepository.Create(bloodSupply);
        }

        public BloodSupply Update(BloodSupply bloodSupply)
        {
            return _bloodSupplyRepository.Update(bloodSupply);
        }

        public void Delete(Guid bloodSupplyId)
        {
            _bloodSupplyRepository.Delete(bloodSupplyId);
        }
        public BloodSupply UpdateByType(string type, double amount)
        {
            BloodSupply bloodSupply = GetByType(type);
            Console.WriteLine("Before: " + type + " " +  bloodSupply.Amount);
            bloodSupply.Amount += amount;
            BloodSupply updated = _bloodSupplyRepository.Update(bloodSupply);;
            Console.WriteLine("After: " + type + " " +  updated.Amount);
            return updated;
        }
    }
}

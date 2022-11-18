using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Repository;
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
            return new List<BloodSupply>(_bloodSupplyRepository.GetAll()).Find(blood => blood.Type.Equals(type));
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
    }
}

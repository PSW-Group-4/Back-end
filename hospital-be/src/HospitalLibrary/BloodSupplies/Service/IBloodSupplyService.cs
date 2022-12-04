using HospitalLibrary.BloodSupplies.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.BloodSupplies.Service
{
    public interface IBloodSupplyService
    {
        IEnumerable<BloodSupply> GetAll();
        BloodSupply GetById(Guid id);
        BloodSupply GetByType(string type);
        BloodSupply Create(BloodSupply bloodSupply);
        BloodSupply Update(BloodSupply bloodSupply);
        void Delete(Guid bloodSupplyId);
        BloodSupply UpdateByType(string type, double amount);
    }
}

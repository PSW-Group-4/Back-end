using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Infrastructure.CRUD;
using IntegrationLibrary.Common;

namespace HospitalLibrary.BloodSupplies.Repository
{
    public interface IBloodSupplyRepository : IRepositoryBase<BloodSupply>
    {
        BloodSupply GetByType(BloodType bloodType);
    }
}

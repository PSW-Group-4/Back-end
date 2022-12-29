using HospitalLibrary.Core.Repository;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.Prescriptions.Model;

namespace HospitalLibrary.Prescriptions.Repository
{
    public interface IPrescriptionRepository : IRepositoryBase<Prescription>
    {
    }
}

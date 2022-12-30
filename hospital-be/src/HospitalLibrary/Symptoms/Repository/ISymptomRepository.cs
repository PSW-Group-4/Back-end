using HospitalLibrary.Core.Repository;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.Symptoms.Model;

namespace HospitalLibrary.Symptoms.Repository
{
    public interface ISymptomRepository : IRepositoryBase<Symptom>
    {
    }
}

using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Patients.Service
{
    public class AgeGroupService : IAgeGroupService
    {
        private readonly IAgeGroupRepository _ageGroupRepository;
        public AgeGroupService(IAgeGroupRepository ageGroupService)
        {
            _ageGroupRepository = ageGroupService;

        }

        public AgeGroup Create(AgeGroup entity)
        {
            return _ageGroupRepository.Create(entity);
        }

        public void Delete(Guid entityId)
        {
             _ageGroupRepository.Delete(entityId);
        }

        public IEnumerable<AgeGroup> GetAll()
        {
            return _ageGroupRepository.GetAll();
        }

        public AgeGroup GetById(Guid id)
        {
            return _ageGroupRepository.GetById(id);
        }

        public AgeGroup Update(AgeGroup entity)
        {
            return _ageGroupRepository.Update(entity);
        }
    }
}

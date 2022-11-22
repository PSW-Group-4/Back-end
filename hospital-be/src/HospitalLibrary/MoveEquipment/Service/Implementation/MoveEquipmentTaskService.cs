using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.MoveEquipment.Repository.Interfaces;

namespace HospitalLibrary.MoveEquipment.Service.Implementation
{
    public class MoveEquipmentTaskService : IMoveEquipmentTaskService
    {
        private readonly IMoveEquipmentTaskRepository _moveEquipmentTaskRepository;

        public MoveEquipmentTaskService(IMoveEquipmentTaskRepository moveEquipmentTaskRepository)
        {
            _moveEquipmentTaskRepository = moveEquipmentTaskRepository;
        }

        public MoveEquipmentTask Create(MoveEquipmentTask entity)
        {
            return _moveEquipmentTaskRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _moveEquipmentTaskRepository.Delete(id);
        }

        public IEnumerable<MoveEquipmentTask> GetAll()
        {
            return _moveEquipmentTaskRepository.GetAll();
        }

        public MoveEquipmentTask GetById(Guid id)
        {
            return _moveEquipmentTaskRepository.GetById(id);
        }

        public MoveEquipmentTask Update(MoveEquipmentTask entity)
        {
            return _moveEquipmentTaskRepository.Update(entity);
        }
    }
}
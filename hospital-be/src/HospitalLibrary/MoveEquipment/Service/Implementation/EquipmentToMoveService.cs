using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.MoveEquipment.Repository.Interfaces;

namespace HospitalLibrary.MoveEquipment.Service.Implementation
{
    public class EquipmentToMoveService : IEquipmentToMoveService
    {
        private readonly IEquipmentToMoveRepository _equipmentToMoveRepository;

        public EquipmentToMoveService(IEquipmentToMoveRepository equipmentToMoveRepository)
        {
            _equipmentToMoveRepository = equipmentToMoveRepository;
        }

        public EquipmentToMove Create(EquipmentToMove entity)
        {
            return _equipmentToMoveRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _equipmentToMoveRepository.Delete(id);
        }

        public IEnumerable<EquipmentToMove> GetAll()
        {
            return _equipmentToMoveRepository.GetAll();
        }

        public EquipmentToMove GetById(Guid id)
        {
            return _equipmentToMoveRepository.GetById(id);
        }

        public EquipmentToMove Update(EquipmentToMove entity)
        {
            return _equipmentToMoveRepository.Update(entity);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;

namespace HospitalLibrary.RoomsAndEqipment.Service.Implementation
{
    public class EquipmentService : IEquipmentService
    {
         private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Equipment Create(Equipment entity)
        {
            return _equipmentRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _equipmentRepository.Delete(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _equipmentRepository.GetAll();
        }

        public Equipment GetById(Guid id)
        {
            return _equipmentRepository.GetById(id);
        }

        public Equipment Update(Equipment entity)
        {
            return _equipmentRepository.Update(entity);
        }
    }
}
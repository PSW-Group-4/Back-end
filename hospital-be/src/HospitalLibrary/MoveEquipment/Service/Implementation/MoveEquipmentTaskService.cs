using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.MoveEquipment.Repository.Interfaces;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Appointments.Model;

namespace HospitalLibrary.MoveEquipment.Service.Implementation
{
    public class MoveEquipmentTaskService : IMoveEquipmentTaskService
    {
        private readonly IMoveEquipmentTaskRepository _moveEquipmentTaskRepository;
        
        private readonly IRoomScheduleService _roomScheduleService;
        private readonly IEquipmentToMoveService _equipmentToMoveService;
        

        public MoveEquipmentTaskService(IMoveEquipmentTaskRepository moveEquipmentTaskRepository, IRoomScheduleService roomScheduleService, IEquipmentToMoveService equipmentToMoveService)
        {
            _moveEquipmentTaskRepository = moveEquipmentTaskRepository;
            _roomScheduleService = roomScheduleService;
            _equipmentToMoveService = equipmentToMoveService;
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

        public void CreateMoveEquipment(InputCreateData data) 
        {
            RoomSchedule sourceSchedule = new RoomSchedule
            {
                Id = Guid.NewGuid(),
                DateTime = data.Date,
                Duration = data.Duration,
                RoomId = Guid.Parse(data.Source)
            };
            RoomSchedule destSchedule = new RoomSchedule
            {
                Id = Guid.NewGuid(),
                DateTime = data.Date,
                Duration = data.Duration,
                RoomId = Guid.Parse(data.Destination)
            };
            List<EquipmentToMove> equipmentToMoveList = new List<EquipmentToMove>();
            EquipmentToMove equipmentToMove = new EquipmentToMove{
                Id = Guid.NewGuid(),
                Amount = UInt64.Parse(data.Amount.ToString()),
                EquipmentId = Guid.Parse(data.Equipment)
            };
            _equipmentToMoveService.Create(equipmentToMove);
            equipmentToMoveList.Add(equipmentToMove);
            _roomScheduleService.Create(sourceSchedule);
            _roomScheduleService.Create(destSchedule);
            this.Create(new MoveEquipmentTask{
                Id = Guid.NewGuid(),
                EquipmentToGive = equipmentToMoveList,
                EquipmentToGet = null,
                RoomSchedule = sourceSchedule,
                RoomScheduleId = sourceSchedule.Id
            });
            this.Create(new MoveEquipmentTask{
                Id = Guid.NewGuid(),
                EquipmentToGive = null,
                EquipmentToGet = equipmentToMoveList,
                RoomSchedule = destSchedule,
                RoomScheduleId = destSchedule.Id
            });
            return;
        }
    }
}
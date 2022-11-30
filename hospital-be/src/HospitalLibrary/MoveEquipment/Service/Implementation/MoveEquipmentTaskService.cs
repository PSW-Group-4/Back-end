using System;
using System.Collections.Generic;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.MoveEquipment.Repository.Interfaces;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Model;
using System.Collections.ObjectModel;

namespace HospitalLibrary.MoveEquipment.Service.Implementation
{
    public class MoveEquipmentTaskService : IMoveEquipmentTaskService
    {
        private readonly IMoveEquipmentTaskRepository _moveEquipmentTaskRepository;
        
        private readonly IRoomScheduleService _roomScheduleService;
        private readonly IEquipmentToMoveService _equipmentToMoveService;
        private readonly IDoctorRoomService _doctorRoomService;
        

        public MoveEquipmentTaskService(IMoveEquipmentTaskRepository moveEquipmentTaskRepository, IRoomScheduleService roomScheduleService, IEquipmentToMoveService equipmentToMoveService, IDoctorRoomService doctorRoomService)
        {
            _moveEquipmentTaskRepository = moveEquipmentTaskRepository;
            _roomScheduleService = roomScheduleService;
            _equipmentToMoveService = equipmentToMoveService;
            _doctorRoomService = doctorRoomService;
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
            Appointment sourceSchedule = new Appointment
            {
                Id = Guid.NewGuid(),
                RoomId = Guid.Parse(data.Source)
            };
            Appointment destSchedule = new Appointment
            {
                Id = Guid.NewGuid(),
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
                Appointment = sourceSchedule,
                RoomScheduleId = sourceSchedule.Id
            });
            this.Create(new MoveEquipmentTask{
                Id = Guid.NewGuid(),
                EquipmentToGive = null,
                EquipmentToGet = equipmentToMoveList,
                Appointment = destSchedule,
                RoomScheduleId = destSchedule.Id
            });
            return;
        }

        public void MoveEquipment(DateTime moveDate)
        {
            IEnumerable<MoveEquipmentTask> list = GetAll();
            foreach (MoveEquipmentTask task in list)
            {
                if((task.Appointment.DateTime.AddMinutes(task.Appointment.Duration) >= moveDate) && !(task.Appointment.IsDone))
                {
                    MoveEquipmentToRoom(task.Id);
                    task.Appointment.IsDone = true;
                    Update(task);
                }
            }
        }

        public void MoveEquipmentToRoom(Guid id)
        {
            MoveEquipmentTask task = GetById(id);
            DoctorRoom room = _doctorRoomService.GetById(task.Appointment.RoomId);
            ICollection<RoomsEquipment> roomsEquipment = new Collection<RoomsEquipment>();
            foreach(EquipmentToMove equipmentToMove in task.EquipmentToGet)
            {
                RoomsEquipment roomsEquipmentToMove = new RoomsEquipment(equipmentToMove.Equipment,room,equipmentToMove.Amount);
                roomsEquipment.Add(roomsEquipmentToMove);
            }
            ICollection<RoomsEquipment> roomsEquipment2 = new Collection<RoomsEquipment>();
            foreach (EquipmentToMove equipmentToMove in task.EquipmentToGive)
            {
                RoomsEquipment roomsEquipmentToMove = new RoomsEquipment(equipmentToMove.Equipment, room, equipmentToMove.Amount);
                roomsEquipment2.Add(roomsEquipmentToMove);
            }

            room.addEquipment(roomsEquipment);
            room.RemoveEquipment(roomsEquipment2);
            _doctorRoomService.Update(room);
        }
    }
}
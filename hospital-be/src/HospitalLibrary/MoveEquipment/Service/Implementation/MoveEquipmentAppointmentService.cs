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
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.MoveEquipment.Service.Implementation
{
    public class MoveEquipmentAppointmentService : IMoveEquipmentAppointmentService
    {
        private readonly IMoveEquipmentAppointmentRepository _moveEquipmentTaskRepository;
        private readonly IEquipmentToMoveService _equipmentToMoveService;
        private readonly IRoomService _roomService;
        

        public MoveEquipmentAppointmentService(IMoveEquipmentAppointmentRepository moveEquipmentTaskRepository, IEquipmentToMoveService equipmentToMoveService, IRoomService roomService)
        {
            _moveEquipmentTaskRepository = moveEquipmentTaskRepository;
            _equipmentToMoveService = equipmentToMoveService;
            _roomService = roomService;
        }

        public MoveEquipmentAppointment Create(MoveEquipmentAppointment entity)
        {
            return _moveEquipmentTaskRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            MoveEquipmentAppointment moveEquipmentAppointment = GetById(id);
            if(moveEquipmentAppointment.AbleToCancel()) 
            {
                return;
            }
            foreach(MoveEquipmentAppointment appointment in GetAll())
            {
                if(moveEquipmentAppointment.IsSameAppointment(appointment))
                {
                    _moveEquipmentTaskRepository.Delete(appointment.Id);
                    break;
                }
            }
            _moveEquipmentTaskRepository.Delete(id);
        }

        public IEnumerable<MoveEquipmentAppointment> GetAll()
        {
            return _moveEquipmentTaskRepository.GetAll();
        }

        public MoveEquipmentAppointment GetById(Guid id)
        {
            return _moveEquipmentTaskRepository.GetById(id);
        }

        public MoveEquipmentAppointment Update(MoveEquipmentAppointment entity)
        {
            return _moveEquipmentTaskRepository.Update(entity);
        }

        public void CreateMoveEquipment(InputCreateData data) 
        {
            MoveEquipmentAppointment appSource = new MoveEquipmentAppointment(MoveEquipmentAppointment.TypeOfMovement.Give, Guid.Parse(data.Equipment), uint.Parse(data.Amount.ToString()), Guid.Parse(data.Source), new DateRange(data.Date, data.Date.AddMinutes(data.Duration)));
            MoveEquipmentAppointment appDest = new MoveEquipmentAppointment(MoveEquipmentAppointment.TypeOfMovement.Get, Guid.Parse(data.Equipment), uint.Parse(data.Amount.ToString()), Guid.Parse(data.Destination), new DateRange(data.Date, data.Date.AddMinutes(data.Duration)));
            this.Create(appSource);
            this.Create(appDest);
        }

        public void MoveEquipment()
        {
            IEnumerable<MoveEquipmentAppointment> list = GetAll();
            foreach (MoveEquipmentAppointment app in list)
            {
                if(app.ShouldBeFinished())
                {
                    MoveEquipmentToRoom(app);
                    app.Finish();
                    Update(app);
                }
            }
        }

        public void MoveEquipmentToRoom(MoveEquipmentAppointment appointment)
        {
            if(appointment.RoomId == null) {
                return;
            }
            Room room = _roomService.GetById((Guid)appointment.RoomId);
            RoomsEquipment roomsEquipmentToMove = appointment.EquipmentToMove.ConvertToRoomsEquipmentForRoom(room);
            if (appointment.Type == MoveEquipmentAppointment.TypeOfMovement.Get) {
                room.AddEquipment(roomsEquipmentToMove);
            }
            else {
                room.RemoveEquipment(roomsEquipmentToMove);
            }
            _roomService.Update(room);
        }
    }
}
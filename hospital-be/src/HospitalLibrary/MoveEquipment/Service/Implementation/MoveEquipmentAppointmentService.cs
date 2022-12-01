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

        //TODO
        public void CreateMoveEquipment(InputCreateData data) 
        {
            DateRange dr = new DateRange(data.Date, data.Date.AddMinutes(data.Duration));
            MoveEquipmentAppointment appSource = new MoveEquipmentAppointment(MoveEquipmentAppointment.TypeOfMovement.Give, Guid.Parse(data.Source), uint.Parse(data.Amount.ToString()), Guid.Parse(data.Source), dr);
            MoveEquipmentAppointment appDest = new MoveEquipmentAppointment(MoveEquipmentAppointment.TypeOfMovement.Get, Guid.Parse(data.Destination), uint.Parse(data.Amount.ToString()), Guid.Parse(data.Source), dr);
            this.Create(appSource);
            this.Create(appDest);
        }

        public void MoveEquipment(DateTime moveDate)
        {
            IEnumerable<MoveEquipmentAppointment> list = GetAll();
            foreach (MoveEquipmentAppointment app in list)
            {
                if((app.DateRange.EndTime <= moveDate) && !(app.IsDone))
                {
                    MoveEquipmentToRoom(app);
                    app.IsDone = true;
                    Update(app);
                }
            }
        }

        public void MoveEquipmentToRoom(MoveEquipmentAppointment appointment)
        {
            Room room = _roomService.GetById(appointment.RoomId);
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
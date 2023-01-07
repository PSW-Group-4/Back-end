using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Renovation.Service.Interfaces;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases.Implementation
{
    public class RenovationSessionService : IRenovationSessionService
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        private IRenovationAppointmentService _appointmentService;        

        public RenovationSessionService(IRenovationSessionAggregateRootRepository sessionRepository, IRenovationAppointmentService appointmentService) {
            this._sessionRepository = sessionRepository;
            this._appointmentService = appointmentService;
        }
        public void ChooseOldRooms(Guid id, IEnumerable<RoomRenovationPlan> rooms) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseOldRooms(root.Id, rooms);
            
        }

        public void ChooseSpecificTime(Guid id, DateTime start, DateTime end) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseSpecificTime(root.Id, start, end);
        }
        public void ChooseType(Guid id, RenovationAppointment.TypeOfRenovation type) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseType(root.Id, type);
        }
        public void CreateNewRooms(Guid id, IEnumerable<RoomRenovationPlan> rooms) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.CreateNewRooms(root.Id, rooms);
        }
        public void CreateTimeframe(Guid id, DateTime start, DateTime end) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.CreateTimeframe(root.Id, start, end);
        }
        public void EndSession(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[0].Id));
            if(root.TypeOfRenovation.Value.Equals(HospitalLibrary.Renovation.Model.RenovationAppointment.TypeOfRenovation.Merge)) {
                this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[1].Id));
            }
            root.EndSession(root.Id);
        }
        public void ReturnedToNewRoomCreation(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToNewRoomCreation(root.Id);
        }

        public void ReturnedToOldRoomsSelection(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToOldRoomSelection(root.Id);
        }
        public void ReturnedToSpecificTimeSelection(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToSpecificTimeSelection(root.Id);
        }
        public void ReturnedToTimeframeCreation(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToTimeframeCreation(root.Id);
        }
        public void ReturnedToTypeSelection(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToTypeSelection(root.Id);
        }
        public Guid StartSession() {
            RenovationSessionAggregateRoot root = new RenovationSessionAggregateRoot(Guid.NewGuid());
            root.StartSession();
            this._sessionRepository.Create(root);
            return root.Id;
        }
    }
}
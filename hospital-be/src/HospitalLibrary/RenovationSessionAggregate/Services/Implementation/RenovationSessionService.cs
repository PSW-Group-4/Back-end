using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Renovation.Service.Interfaces;

namespace HospitalLibrary.RenovationSessionAggregate.Services.Implementation
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
            _sessionRepository.Update(root);
        }

        public void ChooseSpecificTime(Guid id, DateTime start, DateTime end) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseSpecificTime(root.Id, start, end);
            _sessionRepository.Update(root);
        }
        public void ChooseType(Guid id, RenovationAppointment.TypeOfRenovation type) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseType(root.Id, type);
            _sessionRepository.Update(root);
        }
        public void CreateNewRooms(Guid id, IEnumerable<RoomRenovationPlan> rooms) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.CreateNewRooms(root.Id, rooms);
            _sessionRepository.Update(root);
        }
        public void CreateTimeframe(Guid id, DateTime start, DateTime end) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.CreateTimeframe(root.Id, start, end);
            _sessionRepository.Update(root);
        }
        public void EndSession(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[0].Id));
            if(root.TypeOfRenovation.Value.Equals(HospitalLibrary.Renovation.Model.RenovationAppointment.TypeOfRenovation.Merge)) {
                this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[1].Id));
            }
            root.EndSession(root.Id);
        }
        public void ReturnToNewRoomCreation(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToNewRoomCreation(root.Id);
            _sessionRepository.Update(root);
        }

        public void ReturnToOldRoomsSelection(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToOldRoomSelection(root.Id);
            _sessionRepository.Update(root);
        }
        public void ReturnToSpecificTimeSelection(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToSpecificTimeSelection(root.Id);
            _sessionRepository.Update(root);
        }
        public void ReturnToTimeframeCreation(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToTimeframeCreation(root.Id);
            _sessionRepository.Update(root);
        }
        public void ReturnToTypeSelection(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToTypeSelection(root.Id);
            _sessionRepository.Update(root);
        }
        public Guid StartSession() {
            RenovationSessionAggregateRoot root = new RenovationSessionAggregateRoot(Guid.NewGuid());
            root.StartSession();
            this._sessionRepository.Create(root);
            return root.Id;
        }
    }
}
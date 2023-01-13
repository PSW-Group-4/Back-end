using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Renovation.Service.Interfaces;
using HospitalLibrary.RenovationSessionAggregate.Repository.Interfaces;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;

namespace HospitalLibrary.RenovationSessionAggregate.Services.Implementation
{
    public class RenovationSessionService : IRenovationSessionService
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        private IRenovationAppointmentService _appointmentService; 
        private IRenovationSessionEventService _eventService;       

        public RenovationSessionService(IRenovationSessionAggregateRootRepository sessionRepository, IRenovationAppointmentService appointmentService, IRenovationSessionEventService eventService) {
            this._sessionRepository = sessionRepository;
            this._appointmentService = appointmentService;
            this._eventService = eventService;
        }
        public void ChooseOldRooms(Guid id, IEnumerable<RoomRenovationPlan> rooms) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ChooseOldRooms(root.Id, rooms);
            _eventService.Create(new OldRoomsChosen(root.Id, rooms));
            _sessionRepository.Update(root);
        }

        public void ChooseSpecificTime(Guid id, DateTime start, DateTime end) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ChooseSpecificTime(root.Id, start, end);
            _eventService.Create(new SpecificTimeChosen(root.Id, start, end));
            _sessionRepository.Update(root);
        }
        public void ChooseType(Guid id, RenovationAppointment.TypeOfRenovation type) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ChooseType(root.Id, type);
            _eventService.Create(new TypeChosen(root.Id, type));
            _sessionRepository.Update(root);
        }
        public void CreateNewRooms(Guid id, IEnumerable<RoomRenovationPlan> rooms) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.CreateNewRooms(root.Id, rooms);
            _eventService.Create(new NewRoomsCreated(root.Id, rooms));
            _sessionRepository.Update(root);
        }
        public void CreateTimeframe(Guid id, DateTime start, DateTime end) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.CreateTimeframe(root.Id, start, end);
            _eventService.Create(new TimeframeCreated(root.Id, start, end));
            _sessionRepository.Update(root);
        }
        public void EndSession(Guid id) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[0].Id));
            if(root.TypeOfRenovation.Value.Equals(HospitalLibrary.Renovation.Model.RenovationAppointment.TypeOfRenovation.Merge)) {
                this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[1].Id));
            }
            _eventService.Create(new SessionEnded(root.Id));
            root.EndSession(root.Id);
        }
        public void ReturnToNewRoomCreation(Guid id) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ReturnToNewRoomCreation(root.Id);
            _eventService.Create(new ReturnedToNewRoomCreation(root.Id));
            _sessionRepository.Update(root);
        }

        public void ReturnToOldRoomsSelection(Guid id) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ReturnToOldRoomSelection(root.Id);
            _eventService.Create(new ReturnedToOldRoomsSelection(root.Id));
            _sessionRepository.Update(root);
        }
        public void ReturnToSpecificTimeSelection(Guid id) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ReturnToSpecificTimeSelection(root.Id);
            _eventService.Create(new ReturnedToSpecificTimeSelection(root.Id));
            _sessionRepository.Update(root);
        }
        public void ReturnToTimeframeCreation(Guid id) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ReturnToTimeframeCreation(root.Id);
            _eventService.Create(new ReturnedToTimeframeCreation(root.Id));
            _sessionRepository.Update(root);
        }
        public void ReturnToTypeSelection(Guid id) {
            RenovationSessionAggregateRoot root = this.GetById(id);
            root.ReturnToTypeSelection(root.Id);
            _eventService.Create(new ReturnedToTypeSelection(root.Id));
            _sessionRepository.Update(root);
        }
        public Guid StartSession() {
            RenovationSessionAggregateRoot root = new RenovationSessionAggregateRoot(Guid.NewGuid());
            root.StartSession();
            _eventService.Create(new SessionStarted(root.Id));
            this._sessionRepository.Create(root);
            return root.Id;
        }

        public IEnumerable<RenovationSessionAggregateRoot> GetAllFinished() {
            return from root in this.GetAll() where root.IsFinished() select root;
        }

        public IEnumerable<RenovationSessionAggregateRoot> GetAllUnfinished() {
            return from root in this.GetAll() where !root.IsFinished() select root;
        }

        public RenovationSessionAggregateRoot GetById(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.Rehydrate( _eventService.GetAllForRootId(root.Id));
            return root;
        }

        public IEnumerable<RenovationSessionAggregateRoot> GetAll() {
            List<RenovationSessionAggregateRoot> roots = new List<RenovationSessionAggregateRoot>();
            foreach(RenovationSessionAggregateRoot root in this._sessionRepository.GetAll()) {
                root.Rehydrate( _eventService.GetAllForRootId(root.Id));
                roots.Add(root);
            }
            return roots;
        }
    }
}
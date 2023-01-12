using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;

namespace HospitalLibrary.RenovationSessionAggregate.Services.Interfaces
{
    public interface IRenovationSessionService
    {
        public void ChooseOldRooms(Guid id, IEnumerable<RoomRenovationPlan> rooms);
        public void ChooseSpecificTime(Guid id, DateTime start, DateTime end);
        public void ChooseType(Guid id, RenovationAppointment.TypeOfRenovation type);
        public void CreateNewRooms(Guid id, IEnumerable<RoomRenovationPlan> rooms);
        public void CreateTimeframe(Guid id, DateTime start, DateTime end);
        public void EndSession(Guid id);
        public void ReturnToNewRoomCreation(Guid id);
        public void ReturnToOldRoomsSelection(Guid id);
        public void ReturnToSpecificTimeSelection(Guid id);
        public void ReturnToTimeframeCreation(Guid id);
        public void ReturnToTypeSelection(Guid id);
        public Guid StartSession();
        public RenovationSessionAggregateRoot GetById(Guid id);
        public IEnumerable<RenovationSessionAggregateRoot> GetAll();
        public IEnumerable<RenovationSessionAggregateRoot> GetAllFinished();
        public IEnumerable<RenovationSessionAggregateRoot> GetAllUnfinished();
    }
}
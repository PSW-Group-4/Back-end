using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;

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
        public void ReturnedToNewRoomCreation(Guid id);
        public void ReturnedToOldRoomsSelection(Guid id);
        public void ReturnedToSpecificTimeSelection(Guid id);
        public void ReturnedToTimeframeCreation(Guid id);
        public void ReturnedToTypeSelection(Guid id);
        public Guid StartSession(); 
    }
}
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RoomsAndEqipment.Service.Interfaces
{
    public interface IRoomService : ICrudService<Room>
    {
        public void FinishRenovationPlans(IEnumerable<RoomRenovationPlan> plans, RenovationAppointment.TypeOfRenovation typeOfRenovation);
        public void CreateNewRooms(IEnumerable<RoomRenovationPlan> plans, RenovationAppointment.TypeOfRenovation typeOfRenovation);
        public void MoveEquipmentToRoom(Room newRoom, IEnumerable<RoomRenovationPlan> plans);
        public void SetFloorForNewRoom(Room newRoom, IEnumerable<RoomRenovationPlan> plans);
        public void SetMapLocationForNewRoom(Room newRoom, IEnumerable<RoomRenovationPlan> plans, RenovationAppointment.TypeOfRenovation typeOfRenovation, int roomNumber);
        public void RemoveOldRooms(IEnumerable<RoomRenovationPlan> plans);
        List<Room> GetConsiliumRoom();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.BuildingManagmentMap.Service.Interfaces
{
    public interface IRoomMapService : ICrudService<RoomMap>
    {
        public IEnumerable<RoomMap> GetRoomMapsByFloorId(Guid id);
        public Boolean AreAdjacent(Guid roomMap1, Guid roomMap2);
        public MapLocation CalculateNewRoomLocation(IEnumerable<RoomRenovationPlan> plans, RenovationAppointment.TypeOfRenovation typeOfRenovation, int roomNumber);
        public RoomMap GetRoomMapFromRoomId(Guid roomId) ;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.BuildingManagmentMap.Service.Implementation
{
    public class RoomMapService : IRoomMapService
    {

        private readonly IRoomMapRepository _roomMapRepository;
        private readonly IFloorMapRepository _floorMapRepository;

        public RoomMapService(IRoomMapRepository roomMapRepository, IFloorMapRepository floorMapRepository)
        {
            this._roomMapRepository = roomMapRepository;
            this._floorMapRepository = floorMapRepository;
        }

        public RoomMap Create(RoomMap entity)
        {
            return _roomMapRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _roomMapRepository.Delete(id);  
        }

        public IEnumerable<RoomMap> GetAll()
        {
            return _roomMapRepository.GetAll(); 
        }

        public RoomMap GetById(Guid id)
        {
            return _roomMapRepository.GetById(id);   
        }

        public RoomMap Update(RoomMap entity)
        {
            return _roomMapRepository.Update(entity);
        }

        public IEnumerable<RoomMap> GetRoomMapsByFloorId(Guid id) {
            List<RoomMap> returnValue = new List<RoomMap>();
            FloorMap map = _floorMapRepository.GetById(id);
            foreach (Room room in map.Floor.RoomList) {
                foreach(RoomMap roomMap in this.GetAll()) {
                    if (room.Id.Equals(roomMap.Room.Id)) {
                        returnValue.Add(roomMap);
                    }
                }
            } 
            return returnValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.BuildingManagment.Repository.Interfaces;
using HospitalLibrary.BuildingManagment.Service.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.BuildingManagment.Service.Implementation
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _floorRepository;

        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public Floor Create(Floor entity)
        {
            return _floorRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _floorRepository.Delete(id);
        }

        public IEnumerable<Floor> GetAll()
        {
            return _floorRepository.GetAll();
        }

        public Floor GetById(Guid id)
        {
            return _floorRepository.GetById(id);
        }

        public Floor Update(Floor entity)
        {
            return _floorRepository.Update(entity);
        }

        public IEnumerable<Room> GetRoomsByFloorId(Guid id) {
            return this.GetById(id).RoomList;
        }

        public Floor GetFloorByRoomId(Guid id) {
            foreach(Floor floor in this.GetAll()) {
                foreach(Room room in floor.RoomList) {
                    if(room.Id.Equals(id)) {
                        return floor;
                    }
                }
            }
            return null;
        }
    }
}
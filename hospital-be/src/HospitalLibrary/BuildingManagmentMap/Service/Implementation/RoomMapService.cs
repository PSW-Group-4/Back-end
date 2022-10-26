using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;

namespace HospitalLibrary.BuildingManagmentMap.Service.Implementation
{
    public class RoomMapService : IRoomMapService
    {

        private readonly IRoomMapRepository _roomMapRepository;

        public RoomMapService(IRoomMapRepository roomMapRepository)
        {
            this._roomMapRepository = roomMapRepository;
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
    }
}

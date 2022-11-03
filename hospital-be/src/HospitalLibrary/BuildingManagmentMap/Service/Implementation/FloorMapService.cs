using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.BuildingManagment.Model;

namespace HospitalLibrary.BuildingManagmentMap.Service.Implementation
{
    public class FloorMapService : IFloorMapService
    {
        private readonly IFloorMapRepository _floorMapRepository;
        private readonly IBuildingMapRepository _buildingMapRepository;

        public FloorMapService(IFloorMapRepository floorMapRepository, IBuildingMapRepository buildingMapRepository)
        {
            _floorMapRepository = floorMapRepository;
            _buildingMapRepository = buildingMapRepository;
        }   

        public FloorMap Create(FloorMap entity)
        {
            return _floorMapRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _floorMapRepository.Delete(id); 
        }

        public IEnumerable<FloorMap> GetAll()
        {
            return _floorMapRepository.GetAll();
        }

        public FloorMap GetById(Guid id)
        {
            return _floorMapRepository.GetById(id);
        }

        public FloorMap Update(FloorMap entity)
        {
            return _floorMapRepository.Update(entity);
        }

        public IEnumerable<FloorMap> GetFloorMapsByBuildingId(Guid id) {
            List<FloorMap> returnValue = new List<FloorMap>();
            BuildingMap map = _buildingMapRepository.GetById(id);
            foreach (Floor floor in map.Building.FloorList) {
                foreach(FloorMap floorMap in this.GetAll()) {
                    if (floor.Id.Equals(floorMap.Floor.Id)) {
                        returnValue.Add(floorMap);
                    }
                }
            } 
            return returnValue;
        }
    }
}

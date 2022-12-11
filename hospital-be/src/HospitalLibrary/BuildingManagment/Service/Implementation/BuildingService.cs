using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.BuildingManagment.Repository.Interfaces;
using HospitalLibrary.BuildingManagment.Service.Interfaces;

namespace HospitalLibrary.BuildingManagment.Service.Implementation
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepositroy)
        {
            _buildingRepository = buildingRepositroy;
        }

        public Building Create(Building entity)
        {
            return _buildingRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _buildingRepository.Delete(id);
        }

        public IEnumerable<Building> GetAll()
        {
            return _buildingRepository.GetAll();
        }

        public Building GetById(Guid id)
        {
            return _buildingRepository.GetById(id);
        }

        public Building Update(Building entity)
        {
            return _buildingRepository.Update(entity);
        }

        public IEnumerable<Floor> GetFloorsByBuildingId(Guid id) {
            return this.GetById(id).FloorList;
        }
    }
}
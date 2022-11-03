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
    public class BuildingMapService : IBuildingMapService
    {
        private readonly IBuildingMapRepository _buildingMapRepository;

        public BuildingMapService(IBuildingMapRepository buildingMapRepository)
        {
            _buildingMapRepository = buildingMapRepository;
        }

        public BuildingMap Create(BuildingMap entity)
        {
            return _buildingMapRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _buildingMapRepository.Delete(id);  
        }

        public IEnumerable<BuildingMap> GetAll()
        {
            return _buildingMapRepository.GetAll();
        }

        public BuildingMap GetById(Guid id)
        {
            return _buildingMapRepository.GetById(id);
        }

        public BuildingMap Update(BuildingMap entity)
        {
            return _buildingMapRepository.Update(entity);
        }
        
    }
}

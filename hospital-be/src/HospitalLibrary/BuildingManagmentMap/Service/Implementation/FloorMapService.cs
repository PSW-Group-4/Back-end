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
    public class FloorMapService : IFloorMapService
    {
        private readonly IFloorMapRepository _floorMapRepository;

        public FloorMapService(IFloorMapRepository floorMapRepository)
        {
            _floorMapRepository = floorMapRepository;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;

namespace HospitalLibrary.BuildingManagmentMap.Repository.Implementation
{
    public class BuildingMapRepository : IBuildingMapRepository
    {

        private readonly HospitalDbContext _context;

        public BuildingMapRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public BuildingMap Create(BuildingMap entity)
        {
            _context.BuildingMaps.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var buildingMap = GetById(id);
            _context.BuildingMaps.Remove(buildingMap);
            _context.SaveChanges();
        }

        public IEnumerable<BuildingMap> GetAll()
        {
            return _context.BuildingMaps.ToList();
        }

        public BuildingMap GetById(Guid id)
        {
            var result = _context.BuildingMaps.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public BuildingMap Update(BuildingMap entity)
        {
            var updatingBuildingMap = _context.BuildingMaps.SingleOrDefault(p => p.Id == entity.Id);
            if (updatingBuildingMap == null)
            {
                throw new NotFoundException();
            }

            updatingBuildingMap.Update(entity);

            _context.SaveChanges();
            return updatingBuildingMap;
        }
    }
}

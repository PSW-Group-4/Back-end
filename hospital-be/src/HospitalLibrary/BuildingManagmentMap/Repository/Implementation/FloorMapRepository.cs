using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;

namespace HospitalLibrary.BuildingManagmentMap.Repository.Implementation
{
    public class FloorMapRepository : IFloorMapRepository
    {

        private readonly HospitalDbContext _context;

        public FloorMapRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public FloorMap Create(FloorMap entity)
        {
            _context.FloorMaps.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var floorMap = GetById(id);
            _context.FloorMaps.Remove(floorMap);
            _context.SaveChanges();
        }

        public IEnumerable<FloorMap> GetAll()
        {
            return _context.FloorMaps.ToList();
        }

        public FloorMap GetById(Guid id)
        {
            FloorMap result = _context.FloorMaps.Find(id);
            if(result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public FloorMap Update(FloorMap entity)
        {
            var updatingFloorMap = _context.FloorMaps.FirstOrDefault(x => x.Id == entity.Id);
            if (updatingFloorMap == null)
            {
                throw new NotFoundException();
            }

            updatingFloorMap.Update(entity);
            _context.SaveChanges();
            return updatingFloorMap;
        }
    }
}

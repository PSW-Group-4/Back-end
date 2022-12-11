using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.BuildingManagment.Repository.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;

namespace HospitalLibrary.BuildingManagment.Repository.Implementation
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly HospitalDbContext _context;

        public BuildingRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public Building Create(Building entity)
        {
            _context.Buildings.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Buildings.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Building> GetAll()
        {
            return _context.Buildings.ToList();
        }

        public Building GetById(Guid id)
        {
            var result =  _context.Buildings.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Building Update(Building entity)
        {
            var updatingEntity = _context.Buildings.SingleOrDefault(e => e.Id == entity.Id);
            if (updatingEntity == null)
            {
                throw new NotFoundException();
            }
            
            updatingEntity.Update(entity);
            
            _context.SaveChanges();
            return updatingEntity;
        }
    }
}
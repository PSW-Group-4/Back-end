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
    public class FloorRepository : IFloorRepository
    {
        private readonly HospitalDbContext _context;

        public FloorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Floor Create(Floor entity)
        {
            _context.Floors.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Floors.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Floor> GetAll()
        {
            return _context.Floors.ToList();
        }

        public Floor GetById(Guid id)
        {
            var result =  _context.Floors.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Floor Update(Floor entity)
        {
            var updatingEntity = _context.Floors.SingleOrDefault(e => e.Id == entity.Id);
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